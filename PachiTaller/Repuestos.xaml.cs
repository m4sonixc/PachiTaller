namespace PachiTaller;

public partial class Repuestos : ContentPage
{
	public Repuestos()
	{
		InitializeComponent();
	}
    private async void OnVolverInicioClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Inicio");
    }
}
