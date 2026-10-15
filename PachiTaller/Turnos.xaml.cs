namespace PachiTaller;

public partial class Turnos : ContentPage
{
    private readonly DatabaseService _databaseService;

    public Turnos()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarVistaSegunRolAsync();
    }

    private async Task CargarVistaSegunRolAsync()
    {
        if (App.RolSesionActual == "Admin")
        {
            // Muestra la lista de turnos para el Administrador
            PanelAdmin.IsVisible = true;
            PanelUsuario.IsVisible = false;

            var listaTurnos = await _databaseService.ObtenerTodosLosTurnosAsync();
            ListaTurnosView.ItemsSource = listaTurnos;
        }
        else
        {
            // Muestra el formulario de registro para el Cliente
            PanelAdmin.IsVisible = false;
            PanelUsuario.IsVisible = true;
        }
        var todosLosTurnos = await _databaseService.ObtenerTodosLosTurnosAsync();
        var turnosActivos = todosLosTurnos
    .Where(t => t.Estado == "Pendiente" || t.Estado == "En Proceso")
    .ToList();

        ListaTurnosView.ItemsSource = turnosActivos;
    }
    private async void OnEditarTurnoClicked(object sender, EventArgs e)
    {
        try
        {
            var boton = sender as Button;
            var turno = boton?.CommandParameter as TurnoModel;

            if (turno != null)
            {
                var navegacionParametros = new Dictionary<string, object>
            {
                { "Turno", turno }
            };

                // Usamos el nombre registrado para navegar de manera relativa
                await Shell.Current.GoToAsync(nameof(EditarTurnoPage), navegacionParametros);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error de navegación: {ex.Message}");
            await DisplayAlertAsync("Atención", "No se pudo abrir la pantalla de edición.", "OK");
        }
    }
    private async void OnGuardarTurnoClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtNombreCliente.Text) ||
            string.IsNullOrWhiteSpace(TxtVehiculo.Text) ||
            string.IsNullOrWhiteSpace(TxtMotivo.Text))
        {
            await DisplayAlertAsync("Atención", "Por favor, complete todos los campos obligatorios del turno.", "OK");
            return;
        }

        // La fecha del turno se asigna automáticamente con el día actual de la solicitud
        var nuevoTurno = new TurnoModel
        {
            NombreCliente = TxtNombreCliente.Text.Trim(),
            Telefono = TxtTelefonoCliente.Text?.Trim() ?? "",
            Vehiculo = TxtVehiculo.Text.Trim(),
            Motivo = TxtMotivo.Text.Trim(),
            FechaTurno = DateTime.Now.ToString("dd/MM/yyyy"), // Asignación automática de fecha
            Estado = "Pendiente"
        };

        bool exito = await _databaseService.RegistrarTurnoAsync(nuevoTurno);

        if (exito)
        {
            await DisplayAlertAsync("Éxito", "Su turno ha sido registrado correctamente en la base de datos.", "OK");

            // Limpiar formulario
            TxtNombreCliente.Text = string.Empty;
            TxtTelefonoCliente.Text = string.Empty;
            TxtVehiculo.Text = string.Empty;
            TxtMotivo.Text = string.Empty;

            await Shell.Current.GoToAsync("//InicioUsuario");
        }
        else
        {
            await DisplayAlertAsync("Error", "No se pudo registrar el turno. Intente nuevamente.", "OK");
        }
    }
    private async void OnActualizarEstadoClicked(object sender, EventArgs e)
    {
        var boton = sender as Button;
        var turno = boton?.CommandParameter as TurnoModel;

        if (turno != null)
        {
            bool exito = await _databaseService.ActualizarTurnoAdminAsync(
                turno.Id,
                turno.Estado,
                turno.FechaEstimadaTermino,
                turno.Diagnostico
            );

            if (exito)
            {
                await DisplayAlertAsync("Éxito", $"Datos del turno de '{turno.NombreCliente}' actualizados correctamente.", "OK");
                await CargarVistaSegunRolAsync();
            }
            else
            {
                await DisplayAlertAsync("Error", "No se pudieron actualizar los datos del turno.", "OK");
            }
        }
    }

    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        try
        {
            string rutaInicio = App.RolSesionActual == "Admin" ? "//InicioAdmin" : "//InicioUsuario";
            await Shell.Current.GoToAsync(rutaInicio);
        }
        catch
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}