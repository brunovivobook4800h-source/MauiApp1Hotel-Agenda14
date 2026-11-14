
using MauiApp1Hotel.Models;

namespace MauiApp1Hotel
{
    public partial class App : Application
    {
        // Lista de quartos disponíveis no hotel
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 110.0,
                ValorDiariaCrianca = 55.0,
                Detalhes = "Acomodação sofisticada, com ambiente espaçoso e acabamento premium.",
                Imagem = "suite_super_luxo.png"
            },

            new Quarto()
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 80.0,
                ValorDiariaCrianca = 40.0,
                Detalhes = "Acomodação confortável, com decoração moderna e ambiente aconchegante.",
                Imagem = "suite_luxo.png"
            },

            new Quarto()
            {
                Descricao = "Suíte Single",
                ValorDiariaAdulto = 50.0,
                ValorDiariaCrianca = 25.0,
                Detalhes = "Acomodação compacta e funcional, ideal para uma estadia prática.",
                Imagem = "suite_single.png"
            },

            new Quarto()
            {
                Descricao = "Suíte Crise",
                ValorDiariaAdulto = 25.0,
                ValorDiariaCrianca = 12.5,
                Detalhes = "Opção econômica, com estrutura básica para uma hospedagem confortável.",
                Imagem = "suite_crise.png"
            }
        };

        public App()
        {
            InitializeComponent();
        }

        // Inicialização da janela no .NET MAUI 10
        protected override Window CreateWindow(
            IActivationState? activationState)
        {
            var window = new Window(
                new NavigationPage(new Views.ContratacaoHospedagem())
            );

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}
