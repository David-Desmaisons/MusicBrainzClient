using Newtonsoft.Json;
using RestSharpHelper;
using System;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzReleaseGroup : MusicBrainzEntity
    {
        [JsonProperty("primary-type")]
        public string primary_type { get; set; }

        [JsonProperty("artist-credit")]
        public MusicBrainzArtistCredit[] artist_credit { get; set; }

        public string disambiguation { get; set; }

        [JsonProperty("secondary-types")]
        public string[] secondary_types { get; set; }

        public string title { get; set; }

        [JsonProperty("primary-type-id")]
        public string primary_type_id { get; set; }

        [JsonProperty("secondary-type-ids")]
        public string[] secondary_type_ids { get; set; }

        [JsonConverter(typeof(BasicDateTimeConverter))]
        [JsonProperty("first-release-date")]
        public DateTime? first_release_date { get; set; }

        [JsonConverter(typeof(BasicDateTimeConverter))]
        [JsonProperty("release-date")]
        public DateTime? release_date { get; set; }
    }
}