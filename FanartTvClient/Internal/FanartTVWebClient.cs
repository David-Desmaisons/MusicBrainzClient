using System;
using RateLimiter;
using RestSharp;
using RestSharpHelper;

namespace FanartTvClient.Internal 
{
    public class FanartTvWebClient : RestSharpWebClient
    {
        private string _ApiKey;
        protected override string UrlBase => "http://webservice.fanart.tv/v3/music";
        protected override string UserAgentFallBack => @"MuzicBrainzClient https://github.com/David-Desmaisons/MuzicBrainzClient";
        protected override TimeLimiter TimeLimiter => FanartTVWebClientTimeLimiter;

        private const string _AlbumUrl = "/albums/{mbid}";
        private const string _ArtistUrl = "{mbid}";
        private const string _LabelUrl = "labels/{mbid}";

        private static TimeLimiter FanartTVWebClientTimeLimiter { get; set; }

        static FanartTvWebClient() 
        {
            FanartTVWebClientTimeLimiter = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(1));
        }

        public FanartTvWebClient(string apiKey, string userAgent = null, int timeOut = 10000): base(userAgent, timeOut)
        {
            _ApiKey = apiKey;
        }

        public IRestRequest GetArtistRequest(string mbid) 
        {
            return GetRequest(_ArtistUrl, mbid);      
        }

        public IRestRequest GetAlbumRequest(string mbid) 
        {
            return GetRequest(_AlbumUrl, mbid);
        }

        public IRestRequest GetLabelRequest(string mbid)
        {
            return GetRequest(_LabelUrl, mbid);
        }

        private static IRestRequest GetRequest(string url, string mbid) 
        {
            return new RestRequest(url).AddUrlSegment(nameof(mbid), mbid);
        }

        protected override IRestRequest Mature(IRestRequest request) 
        {
            return request.AddQueryParameter("api_key", _ApiKey);
        }
    }
}
