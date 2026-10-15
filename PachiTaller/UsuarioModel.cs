using SQLite;

namespace PachiTaller
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        [Unique]
        public string Usuario { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        // "Admin" o "Cliente"
        public string Rol { get; set; } = string.Empty;
    }
}