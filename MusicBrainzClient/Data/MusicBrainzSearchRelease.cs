using System;
using Newtonsoft.Json;
using RestSharpHelper;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzRelease : MusicBrainzEntity
    {
        public int score { get; set; }
        public int count { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string country { get; set; }
        public string packaging { get; set; }
        public string barcode { get; set; }

        [JsonProperty("cover-art-archive")]
        public MusicBrainzCoverArtArchive cover_art_archive { get; set; }

        [JsonProperty("text-representation")]
        public MusicBrainzTextRepresentation text_representation { get; set; }

        [JsonProperty("artist-credit")]
        public MusicBrainzArtistCredit[] artist_credit { get; set; }

        [JsonProperty("release-group")]
        public MusicBrainzReleaseGroup release_group { get; set; }

        [JsonConverter(typeof(BasicDateTimeConverter))]
        public DateTime? date { get; set; }

        [JsonProperty("release-events")]
        public MusicBrainzReleaseEvent[] release_events { get; set; }

        [JsonProperty("label-info")]
        public MusicBrainzLabelInfo[] label_info { get; set; }

        [JsonProperty("track-count")]
        public int track_count { get; set; }
        public MusicBrainzMedium[] media { get; set; }
    }
}