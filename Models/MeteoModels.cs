using System.Text.Json.Serialization;

namespace MeteoApp.Models
{
    public class MeteoReponse
    {
        
        [JsonPropertyName("current_weather")] 
        public CurrentMeteo? Current { get; set; }
    }

    public class CurrentMeteo
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
        
        [JsonPropertyName("weathercode")]
        public int MeteoCode { get; set; } 
    }
}