using System.Text.Json.Serialization;

namespace DesafioItaú.Dto
{
    public class EstatisticaDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("sum")]
        public double Sum { get; set; }

        [JsonPropertyName("avg")]
        public double Avg { get; set; }

        [JsonPropertyName("min")]
        public double Min { get; set; }

        [JsonPropertyName("max")]
        public double Max { get; set; }
    }
}
