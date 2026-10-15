namespace PachiTaller;

public partial class Repuestos : ContentPage
{
    private readonly DatabaseService _databaseService;

    public Repuestos()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarRepuestosAsync();
    }

    private async Task CargarRepuestosAsync()
    {
        try
        {
            var lista = await _databaseService.ObtenerTodosLosRepuestosAsync();
            ListaRepuestosView.ItemsSource = null;
            ListaRepuestosView.ItemsSource = lista;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error al cargar repuestos: {ex.Message}");
        }
    }

    private async void OnGuardarRepuestoClicked(object sender, EventArgs e)
    {
        try
        {
            string nombre = TxtNombreRepuesto.Text?.Trim() ?? "";
            string categoria = string.IsNullOrWhiteSpace(TxtCategoria.Text) ? "General" : TxtCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                !int.TryParse(TxtStock.Text, out int stock) ||
                !decimal.TryParse(TxtPrecio.Text, out decimal precio))
            {
                await DisplayAlertAsync("Atención", "Por favor complete nombre, stock y precio correctamente.", "OK");
                return;
            }

            var nuevoRepuesto = new RepuestoModel
            {
                Nombre = nombre,
                Categoria = categoria,
                Stock = stock,
                Precio = precio
            };

            bool exito = await _databaseService.RegistrarRepuestoAsync(nuevoRepuesto);

            if (exito)
            {
                // El await asegura que el cartel se cierre limpiamente en Android antes de continuar
                await DisplayAlertAsync("Éxito", "Repuesto guardado correctamente en el inventario.", "OK");

                // Limpiamos los campos de texto
                TxtNombreRepuesto.Text = string.Empty;
                TxtCategoria.Text = string.Empty;
                TxtStock.Text = string.Empty;
                TxtPrecio.Text = string.Empty;

                // Actualizamos la lista de repuestos visible
                await CargarRepuestosAsync();
            }
            else
            {
                await DisplayAlertAsync("Error", "No se pudo guardar el repuesto en la base de datos.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error de ejecución", $"Ocurrió un detalle al guardar: {ex.Message}", "OK");
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