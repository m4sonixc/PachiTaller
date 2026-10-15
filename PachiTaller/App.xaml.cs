namespace PachiTaller;

public partial class App : Application
{
    // Variable global para recordar el perfil iniciado ("Admin" o "Cliente")
    public static string RolSesionActual { get; set; } = "Admin";

    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
        MainPage = new AppShell();
    }
}