namespace PachiTaller;

public partial class EstadoTurnoPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public EstadoTurnoPage()
    {
        InitializeComponent();
        _databaseService = new DatabaseService();
    }

    // Se ejecuta cada vez que la pantalla se hace visible en la app
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CargarTurnosUsuarioAsync();
    }

    private async Task CargarTurnosUsuarioAsync()
    {
        // Traemos todos los turnos con la información más reciente de SQLite
        var todosLosTurnos = await _databaseService.ObtenerTodosLosTurnosAsync();

        // Limpiamos y asignamos nuevamente la fuente de datos para forzar la actualización del CollectionView
        ListaTurnosUsuarioView.ItemsSource = null;
        ListaTurnosUsuarioView.ItemsSource = todosLosTurnos;
    }

    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("//InicioUsuario");
        }
        catch
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}