using Newtonsoft.Json;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzArea : MusicBrainzEntity
    {
        public string name { get; set; }

        public string disambiguation { get; set; }

        [JsonProperty("sort-name")]
        public string sort_name { get; set; }

        [JsonProperty("iso-3166-1-codes")]
        public string[] iso_3166_1_codes { get; set; }
    }
}