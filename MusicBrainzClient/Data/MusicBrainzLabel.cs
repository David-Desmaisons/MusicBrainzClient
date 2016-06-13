using Newtonsoft.Json;

namespace MusicBrainzClient.Data
{
    public class MusicBrainzLabel : MusicBrainzEntity
    {
        public string name { get; set; }
        [JsonProperty("label-code")]
        public int label_code { get; set; }
        [JsonProperty("sort-name")]
        public string sort_name { get; set; }
        public string disambiguation { get; set; }
    }
}