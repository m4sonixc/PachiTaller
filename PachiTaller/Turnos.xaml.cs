namespace PachiTaller;

public partial class Turnos : ContentPage
{
	public Turnos()
	{
		InitializeComponent();
	}
    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Inicio");
    }
}