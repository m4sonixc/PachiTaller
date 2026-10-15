namespace PachiTaller;

public partial class Historial : ContentPage
{
    private readonly DatabaseService _databaseService;

    public Historial()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarHistorialAsync();
    }

    private async Task CargarHistorialAsync()
    {
        try
        {
            var historial = await _databaseService.ObtenerHistorialTurnosAsync();
            ListaHistorialView.ItemsSource = null;
            ListaHistorialView.ItemsSource = historial;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error al cargar el historial: {ex.Message}");
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