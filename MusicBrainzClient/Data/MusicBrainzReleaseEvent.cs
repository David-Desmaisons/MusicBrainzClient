using System;
using Newtonsoft.Json;
using RestSharpHelper;

namespace MusicBrainzClient.Data
{
    public class MusicBrainzReleaseEvent 
    {
        [JsonConverter(typeof(BasicDateTimeConverter))]
        public DateTime? date { get; set; }
        public MusicBrainzArea area { get; set; }
    }
}