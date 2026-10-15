namespace PachiTaller;

[QueryProperty(nameof(TurnoSeleccionado), "Turno")]
public partial class EditarTurnoPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private TurnoModel? _turno;

    public TurnoModel? TurnoSeleccionado
    {
        get => _turno;
        set
        {
            _turno = value;
            OnPropertyChanged();
            CargarDatos();
        }
    }

    public EditarTurnoPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarRepuestosDisponiblesAsync();
    }

    private void CargarDatos()
    {
        try
        {
            if (_turno == null) return;

            LblVehiculo.Text = $"🚗 Vehículo: {_turno.Vehiculo}";
            LblCliente.Text = $"👤 Cliente: {_turno.NombreCliente} ({_turno.Telefono})";
            LblMotivo.Text = $"🛠️ Motivo: {_turno.Motivo}";

            PickerEstado.SelectedItem = string.IsNullOrEmpty(_turno.Estado) ? "Pendiente" : _turno.Estado;
            TxtDiagnostico.Text = _turno.Diagnostico == "Pendiente de revisión en taller" ? "" : _turno.Diagnostico;

            if (DateTime.TryParse(_turno.FechaEstimadaTermino, out DateTime fechaParsed))
            {
                PickerFechaEntrega.Date = fechaParsed;
            }
            else
            {
                PickerFechaEntrega.Date = DateTime.Today.AddDays(1);
            }

            TxtManoObra.Text = _turno.CostoManoObra > 0 ? _turno.CostoManoObra.ToString("0") : "";
            LblCostoRepuestos.Text = $"${_turno.CostoRepuestos:N0}";
            LblCostoTotal.Text = $"${_turno.CostoTotal:N0}";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error al asignar datos en EditarTurnoPage: {ex.Message}");
        }
    }

    private async Task CargarRepuestosDisponiblesAsync()
    {
        try
        {
            var repuestos = await _databaseService.ObtenerTodosLosRepuestosAsync();
            PickerRepuestosStock.ItemsSource = null;
            PickerRepuestosStock.ItemsSource = repuestos;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error al cargar repuestos: {ex.Message}");
        }
    }

    // --- MÉTODOS REQUERIDOS POR EL XAML ---

    public async void OnAgregarRepuestoClicked(object sender, EventArgs e)
    {
        try
        {
            if (_turno == null) return;

            var repuestoSeleccionado = PickerRepuestosStock.SelectedItem as RepuestoModel;

            if (repuestoSeleccionado == null)
            {
                await DisplayAlertAsync("Atención", "Por favor, seleccione un repuesto de la lista.", "OK");
                return;
            }

            if (repuestoSeleccionado.Stock < 1)
            {
                await DisplayAlertAsync("Sin Stock", $"No hay stock disponible de '{repuestoSeleccionado.Nombre}'.", "OK");
                return;
            }

            bool exito = await _databaseService.UsarRepuestoEnTurnoAsync(_turno.Id, repuestoSeleccionado, 1);

            if (exito)
            {
                _turno.CostoRepuestos += repuestoSeleccionado.Precio;
                LblCostoRepuestos.Text = $"${_turno.CostoRepuestos:N0}";
                RecalcularTotal();

                await DisplayAlertAsync("Éxito", $"Se agregó '{repuestoSeleccionado.Nombre}' al turno y se descontó 1 unidad del stock.", "OK");
                await CargarRepuestosDisponiblesAsync();
            }
            else
            {
                await DisplayAlertAsync("Error", "No se pudo descontar el repuesto.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Ocurrió un problema: {ex.Message}", "OK");
        }
    }

    public void OnCalcularTotal(object sender, EventArgs e)
    {
        RecalcularTotal();
    }

    private void RecalcularTotal()
    {
        decimal.TryParse(TxtManoObra.Text, out decimal manoObra);
        decimal repuestos = _turno?.CostoRepuestos ?? 0;
        decimal total = manoObra + repuestos;
        LblCostoTotal.Text = $"${total:N0}";
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        try
        {
            if (_turno == null) return;

            string nuevoEstado = PickerEstado.SelectedItem?.ToString() ?? "Pendiente";
            string nuevoDiagnostico = TxtDiagnostico.Text?.Trim() ?? "Sin diagnóstico";
            DateTime fechaSeleccionada = PickerFechaEntrega.Date ?? DateTime.Today;
            string nuevaFechaEntrega = fechaSeleccionada.ToString("dd/MM/yyyy");

            decimal.TryParse(TxtManoObra.Text, out decimal manoObra);

            bool exito = await _databaseService.ActualizarTurnoCompletoAsync(
                _turno.Id,
                nuevoEstado,
                nuevaFechaEntrega,
                string.IsNullOrWhiteSpace(nuevoDiagnostico) ? "Sin diagnóstico" : nuevoDiagnostico,
                manoObra
            );

            if (exito)
            {
                await DisplayAlertAsync("Éxito", "Los cambios han sido guardados correctamente.", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlertAsync("Error", "No se pudieron guardar los datos.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Ocurrió un problema: {ex.Message}", "OK");
        }
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}