namespace PachiTaller;

public partial class Historial : ContentPage
{
	public Historial()
	{
		InitializeComponent();
	}
    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Inicio");
    }
}