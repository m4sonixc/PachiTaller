namespace PachiTaller
{
    public partial class UsuarioMainPage : ContentPage
    {
        public UsuarioMainPage()
        {
            InitializeComponent();
        }

        private async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }

        private async void OnRegistrarTurnoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Turnos");
        }

        private async void OnEstadoTurnoClicked(object sender, EventArgs e)
        {
            // Redirige directamente a la pantalla con las tarjetas/cajas de turnos
            await Shell.Current.GoToAsync("//EstadoTurno");
        }
        private async void OnHistorialTurnosClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Historial");
        }
    }
}