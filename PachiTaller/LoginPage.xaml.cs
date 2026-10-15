namespace PachiTaller
{
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public LoginPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnIngresarClicked(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text?.Trim() ?? "";
            string password = TxtPassword.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                await DisplayAlertAsync("Atención", "Por favor, complete usuario y contraseña.", "OK");
                return;
            }

            var usuarioEncontrado = await _databaseService.ValidarUsuarioAsync(usuario, password);

            if (usuarioEncontrado == null)
            {
                await DisplayAlertAsync("Error", "Usuario o contraseña incorrectos.", "OK");
                return;
            }

            // Guardamos el rol en la sesión global
            App.RolSesionActual = usuarioEncontrado.Rol;

            if (usuarioEncontrado.Rol == "Admin")
            {
                await Shell.Current.GoToAsync("//InicioAdmin");
            }
            else
            {
                await Shell.Current.GoToAsync("//InicioUsuario");
            }
        }

        private async void OnRegistrarseClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Registro");
        }
    }
}