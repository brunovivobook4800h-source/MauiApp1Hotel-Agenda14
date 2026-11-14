
namespace MauiApp1Hotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Acessa os dados cadastrados no App.xaml.cs
        PropriedadesApp = (App)Application.Current!;

        // Carrega os quartos disponíveis no Picker
        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        // Configura as datas de check-in
        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddMonths(1);
        dtpck_checkin.Date = DateTime.Today;

        // Configura as datas de check-out
        AtualizarDatasCheckout(DateTime.Today);
    }

    // Atualiza o período permitido para o check-out
    private void AtualizarDatasCheckout(DateTime dataCheckin)
    {
        DateTime dataMinima = dataCheckin.AddDays(1);
        DateTime dataMaxima = dataCheckin.AddMonths(6);

        dtpck_checkout.MinimumDate = dataMinima;
        dtpck_checkout.MaximumDate = dataMaxima;

        // Garante que o check-out seja posterior ao check-in
        if (dtpck_checkout.Date == null ||
            dtpck_checkout.Date < dataMinima ||
            dtpck_checkout.Date > dataMaxima)
        {
            dtpck_checkout.Date = dataMinima;
        }
    }

    // Executado quando o usuário altera o check-in
    private void dtpck_checkin_DateSelected(
        object sender, DateChangedEventArgs e)
    {
        if (e.NewDate is DateTime dataSelecionada)
        {
            AtualizarDatasCheckout(dataSelecionada);
        }
    }

    // Botão Avançar
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Verifica se uma suíte foi selecionada
            if (pck_quarto.SelectedItem == null)
            {
                await DisplayAlert(
                    "Atenção",
                    "Selecione uma suíte para continuar.",
                    "OK"
                );

                return;
            }

            // Verifica se as datas foram selecionadas
            if (dtpck_checkin.Date == null ||
                dtpck_checkout.Date == null)
            {
                await DisplayAlert(
                    "Atenção",
                    "Selecione as datas da hospedagem.",
                    "OK"
                );

                return;
            }

            // Verifica se o check-out é posterior ao check-in
            if (dtpck_checkout.Date <= dtpck_checkin.Date)
            {
                await DisplayAlert(
                    "Atenção",
                    "O check-out deve ser posterior ao check-in.",
                    "OK"
                );

                return;
            }

            // Abre a página de resumo da hospedagem
            await Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Novo botão: Conheça Nossas Suítes
    private async void OnSuitesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SuitesDisponiveis());
    }

    // Botão Sobre o aplicativo
    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
