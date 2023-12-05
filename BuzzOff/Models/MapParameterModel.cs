using Newtonsoft.Json;

namespace BuzzOff.Models
{
    public class MapParameterModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
