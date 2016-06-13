using Newtonsoft.Json;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzMedium 
    {
        public string format { get; set; }

        [JsonProperty("format-id")]
        public string format_id { get; set; }

        [JsonProperty("disc-count")]
        public int disc_count { get; set; }

        [JsonProperty("track-count")]
        public int track_count { get; set; }

        [JsonProperty("track-offset")]
        public int track_offset { get; set; }

        public string title { get; set; }

        public MusicBrainzTrack[] tracks { get; set; }

        public int position { get; set; }
    }
}