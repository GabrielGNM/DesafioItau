using System.Text.Json.Serialization;

namespace DesafioItaú.Dto
{
    public class TrasacaoDto
    {
        [JsonPropertyName("valor")]
        public double Valor { get; set; }

        [JsonPropertyName("dataHora")]
        public DateTime DataHora { get; set; }
    }
}
