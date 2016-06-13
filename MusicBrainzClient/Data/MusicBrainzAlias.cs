using System;
using Newtonsoft.Json;

namespace MusicBrainzClient.Data 
{
    public class MusicBrainzAlias
    {
        public string name { get; set; }
        public string locale { get; set; }
        public string type { get; set; }
        public string primary { get; set; }

        [JsonProperty("begin-date")]
        public DateTime? begin_date { get; set; }

        [JsonProperty("end-date")]
        public DateTime? end_date { get; set; }

        [JsonProperty("sort-name")]
        public string sort_name { get; set; }
    }
}