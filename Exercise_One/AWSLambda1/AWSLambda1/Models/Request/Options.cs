using System.Text.Json.Serialization;

namespace AWSLambda1.Models.Request
{
    public class Options
    {
        [JsonPropertyName("option")]
        public string Option { get; set; }
    }
}
