using Newtonsoft.Json;

namespace MusicBrainzClient.Data
{
    public class MusicBrainzTrack
    {
        public string title { get; set; }

        [JsonProperty("artist-credit")]
        public MusicBrainzArtistCredit[] artist_credit { get; set; }

        public string number { get; set; }

        public MusicBrainzRecording recording { get; set; }

        public int length { get; set; }
    }
}