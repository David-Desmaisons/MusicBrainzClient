using Newtonsoft.Json;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzArtist : MusicBrainzEntity
    {
        public string name { get; set; }

        [JsonProperty("sort-name")]
        public string sort_name { get; set; }
        public string disambiguation { get; set; }
        public MusicBrainzAlias[] aliases { get; set; }

        public string type { get; set; }
        public int score { get; set; }
        public string gender { get; set; }

        [JsonProperty("gender-id")]
        public string gender_id { get; set; }

        public string country { get; set; }
        public MusicBrainzArea area { get; set; }
        public MusicBrainzArea begin_area { get; set; }
        public MusicBrainzArea end_area { get; set; }

        [JsonProperty("life-span")]
        public MusicBrainzLifeSpan life_span { get; set; }
        public MusicBrainzTag[] tags { get; set; }
    }
}