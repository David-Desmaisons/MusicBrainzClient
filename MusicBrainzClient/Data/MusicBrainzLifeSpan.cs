using Newtonsoft.Json;
using RestSharpHelper;
using System;

namespace MusicBrainzClient.Data
{
    public class MusicBrainzLifeSpan
    {
        [JsonConverter(typeof(BasicDateTimeConverter))]
        public DateTime? begin { get; set; }

        [JsonConverter(typeof(BasicDateTimeConverter))]
        public DateTime? end { get; set; }

        public bool? ended { get; set; }
    }
}