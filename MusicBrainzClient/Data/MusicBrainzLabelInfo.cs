using Newtonsoft.Json;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzLabelInfo 
    {
        [JsonProperty("catalog-number")]
        public string catalog_number { get; set; }
        public MusicBrainzLabel label { get; set; }
    }
}