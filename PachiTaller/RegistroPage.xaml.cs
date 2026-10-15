namespace PachiTaller
{
    public partial class RegistroPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public RegistroPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnVolverLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }

        private async void OnConfirmarRegistroClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                string.IsNullOrWhiteSpace(TxtRegUsuario.Text) ||
                string.IsNullOrWhiteSpace(TxtRegPassword.Text))
            {
                await DisplayAlertAsync("Atención", "Por favor, complete los campos obligatorios.", "OK");
                return;
            }

            var nuevoCliente = new UsuarioModel
            {
                Nombre = TxtNombre.Text.Trim(),
                Telefono = TxtTelefono.Text?.Trim() ?? "",
                Usuario = TxtRegUsuario.Text.Trim(),
                Password = TxtRegPassword.Text.Trim()
            };

            bool resultado = await _databaseService.RegistrarUsuarioAsync(nuevoCliente);

            if (resultado)
            {
                await DisplayAlertAsync("Éxito", "Usuario guardado en SQLite con éxito. Ya puedes iniciar sesión.", "OK");
                await Shell.Current.GoToAsync("//Login");
            }
            else
            {
                await DisplayAlertAsync("Error", "El nombre de usuario ya se encuentra registrado.", "OK");
            }
        }
    }
}