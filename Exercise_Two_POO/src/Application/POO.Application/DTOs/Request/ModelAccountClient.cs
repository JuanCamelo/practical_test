using System.Text.Json.Serialization;

namespace POO.Application.DTOs.Request
{
    public class ModelAccountClient
    {
        [JsonPropertyName("client")]
        public string Client { get; set; } = string.Empty;
        [JsonPropertyName("document")]
        public int Document { get; set; }
        [JsonPropertyName("typeAccount")]
        public string TypeAccount { get; set; }= string.Empty;
        [JsonPropertyName("balance")]
        public double Balance { get; set; }
    }
}
