
namespace MauiApp1Hotel.Views;

public partial class SuitesDisponiveis : ContentPage
{
    public SuitesDisponiveis()
    {
        InitializeComponent();
    }

    // Botão Voltar
    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
