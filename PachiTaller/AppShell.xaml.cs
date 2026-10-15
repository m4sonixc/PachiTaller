namespace PachiTaller;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registrar la ruta de la página de edición para navegación
        Routing.RegisterRoute(nameof(EditarTurnoPage), typeof(EditarTurnoPage));
    }
}