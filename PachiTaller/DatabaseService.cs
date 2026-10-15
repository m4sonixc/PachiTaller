using SQLite;

namespace PachiTaller
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection? _database;

        private async Task<SQLiteAsyncConnection> GetDatabaseConnectionAsync()
        {
            if (_database != null)
                return _database;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "pachigarage.db3");
            _database = new SQLiteAsyncConnection(dbPath);

            // Crear y asegurar la existencia de todas las tablas necesarias
            await _database.CreateTableAsync<UsuarioModel>();
            await _database.CreateTableAsync<TurnoModel>();
            await _database.CreateTableAsync<RepuestoModel>(); // Asegura la tabla Repuestos

            var conteoUsuarios = await _database.Table<UsuarioModel>().CountAsync();

            if (conteoUsuarios == 0)
            {
                var admin = new UsuarioModel
                {
                    Nombre = "Administrador Pachi Garage",
                    Usuario = "admin",
                    Password = "123",
                    Telefono = "3704000000",
                    Rol = "Admin"
                };

                var clienteEjemplo = new UsuarioModel
                {
                    Nombre = "Juan Pérez",
                    Usuario = "cliente",
                    Password = "123",
                    Telefono = "3704123456",
                    Rol = "Cliente"
                };

                await _database.InsertAsync(admin);
                await _database.InsertAsync(clienteEjemplo);

                // Cargar un turno inicial de ejemplo
                var turnoEjemplo = new TurnoModel
                {
                    NombreCliente = "Juan Pérez",
                    Telefono = "3704123456",
                    Vehiculo = "Ford Ranger - AB 123 CD",
                    Motivo = "Revisión general de frenos y alineación",
                    FechaTurno = DateTime.Now.ToString("dd/MM/yyyy"),
                    Estado = "Pendiente"
                };
                await _database.InsertAsync(turnoEjemplo);
            }

            return _database;
        }

        // --- AUTENTICACIÓN Y USUARIOS ---

        public async Task<UsuarioModel?> ValidarUsuarioAsync(string usuario, string password)
        {
            var db = await GetDatabaseConnectionAsync();
            return await db.Table<UsuarioModel>()
                           .Where(u => u.Usuario.ToLower() == usuario.ToLower() && u.Password == password)
                           .FirstOrDefaultAsync();
        }

        public async Task<bool> RegistrarUsuarioAsync(UsuarioModel nuevoUsuario)
        {
            var db = await GetDatabaseConnectionAsync();
            var existe = await db.Table<UsuarioModel>()
                                 .Where(u => u.Usuario.ToLower() == nuevoUsuario.Usuario.ToLower())
                                 .FirstOrDefaultAsync();

            if (existe != null) return false;

            nuevoUsuario.Rol = "Cliente";
            await db.InsertAsync(nuevoUsuario);
            return true;
        }

        // --- GESTIÓN DE TURNOS ---

        public async Task<List<TurnoModel>> ObtenerTodosLosTurnosAsync()
        {
            var db = await GetDatabaseConnectionAsync();
            return await db.Table<TurnoModel>().OrderByDescending(t => t.Id).ToListAsync();
        }

        public async Task<bool> RegistrarTurnoAsync(TurnoModel nuevoTurno)
        {
            var db = await GetDatabaseConnectionAsync();
            int resultado = await db.InsertAsync(nuevoTurno);
            return resultado > 0;
        }

        public async Task<bool> ActualizarTurnoAdminAsync(int turnoId, string nuevoEstado, string fechaEstimada, string diagnostico)
        {
            var db = await GetDatabaseConnectionAsync();
            var turno = await db.Table<TurnoModel>().Where(t => t.Id == turnoId).FirstOrDefaultAsync();

            if (turno != null)
            {
                turno.Estado = nuevoEstado;
                turno.FechaEstimadaTermino = string.IsNullOrWhiteSpace(fechaEstimada) ? "Sin definir" : fechaEstimada;
                turno.Diagnostico = string.IsNullOrWhiteSpace(diagnostico) ? "Sin diagnóstico" : diagnostico;

                int filasAfectadas = await db.UpdateAsync(turno);
                return filasAfectadas > 0;
            }

            return false;
        }

        public async Task<bool> ActualizarTurnoCompletoAsync(int turnoId, string nuevoEstado, string fechaEstimada, string diagnostico, decimal manoObra)
        {
            var db = await GetDatabaseConnectionAsync();
            var turno = await db.Table<TurnoModel>().Where(t => t.Id == turnoId).FirstOrDefaultAsync();

            if (turno != null)
            {
                turno.Estado = nuevoEstado;
                turno.FechaEstimadaTermino = string.IsNullOrWhiteSpace(fechaEstimada) ? "Sin definir" : fechaEstimada;
                turno.Diagnostico = string.IsNullOrWhiteSpace(diagnostico) ? "Sin diagnóstico" : diagnostico;
                turno.CostoManoObra = manoObra;

                int filasAfectadas = await db.UpdateAsync(turno);
                return filasAfectadas > 0;
            }

            return false;
        }

        // Obtener únicamente los turnos finalizados o cancelados para el historial
        public async Task<List<TurnoModel>> ObtenerHistorialTurnosAsync()
        {
            var db = await GetDatabaseConnectionAsync();
            return await db.Table<TurnoModel>()
                           .Where(t => t.Estado == "Finalizado" || t.Estado == "Cancelado")
                           .OrderByDescending(t => t.Id)
                           .ToListAsync();
        }

        // --- GESTIÓN DE REPUESTOS E INVENTARIO ---

        public async Task<List<RepuestoModel>> ObtenerTodosLosRepuestosAsync()
        {
            var db = await GetDatabaseConnectionAsync();
            return await db.Table<RepuestoModel>().OrderBy(r => r.Nombre).ToListAsync();
        }

        public async Task<bool> RegistrarRepuestoAsync(RepuestoModel nuevoRepuesto)
        {
            var db = await GetDatabaseConnectionAsync();
            int resultado = await db.InsertAsync(nuevoRepuesto);
            return resultado > 0;
        }

        public async Task<bool> UsarRepuestoEnTurnoAsync(int turnoId, RepuestoModel repuesto, int cantidad)
        {
            var db = await GetDatabaseConnectionAsync();
            var turno = await db.Table<TurnoModel>().Where(t => t.Id == turnoId).FirstOrDefaultAsync();

            if (turno != null && repuesto.Stock >= cantidad)
            {
                // Descontar del stock en inventario
                repuesto.Stock -= cantidad;
                await db.UpdateAsync(repuesto);

                // Acumular costo del repuesto en el turno
                turno.CostoRepuestos += (repuesto.Precio * cantidad);
                await db.UpdateAsync(turno);

                return true;
            }

            return false;
        }
    }
}