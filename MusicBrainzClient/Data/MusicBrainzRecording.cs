using Newtonsoft.Json;

namespace MusicBrainzClient.Data
{
    public class MusicBrainzRecording : MusicBrainzEntity
    {
        public int length { get; set; }
        public string disambiguation { get; set; }
        public bool video { get; set; }
        public string title { get; set; }

        [JsonProperty("artist-credit")]
        public MusicBrainzArtistCredit[] artist_credit { get; set; }
    }
}