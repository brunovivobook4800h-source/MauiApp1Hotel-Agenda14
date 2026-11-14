
namespace MauiApp1Hotel.Models
{
    public class Quarto
    {
        // Nome da suíte
        public string Descricao { get; set; } = string.Empty;

        // Valor da diária por adulto
        public double ValorDiariaAdulto { get; set; }

        // Valor da diária por criança
        public double ValorDiariaCrianca { get; set; }

        // Descrição detalhada da acomodação
        public string Detalhes { get; set; } = string.Empty;

        // Nome do arquivo de imagem
        public string Imagem { get; set; } = string.Empty;
    }
}
