namespace PachiTaller
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //  esto permite que se navege hacia la pestaña de historial de vehiculos y asi se repite el mismo proceso con los demas eventos
        private async void OnTurnosClicked(object sender, EventArgs e)
        {
            // 
            await Shell.Current.GoToAsync("//Turnos");
        }

        private async void OnHistorialClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Historial");
        }

        // esto seria de repuestos pero que invalido con comentarios 
         private async void OnRepuestosClicked(object sender, EventArgs e)
        {
            // Navega de forma segura utilizando la ruta registrada en AppShell
            await Shell.Current.GoToAsync("//Repuestos");
        }
    }
}
