using RateLimiter;
using RestSharp;
using RestSharpHelper;

namespace MusicBrainzClient.Internal
{
    internal class CoverArtArchiveWebClient : RestSharpWebClient
    {
        private const string _ReleaseUrl = "release/{releaseId}";
        private const string _ReleaseGroupUrl = "release-group/{releaseGroupId}";

        protected override string UrlBase => "http://coverartarchive.org";

        protected override string UserAgentFallBack=> @"MuzicBrainzClient https://github.com/David-Desmaisons/MuzicBrainzClient";

        protected override TimeLimiter TimeLimiter => MusicBrainzRateLimiter.MuzicBrainzTimeLimiter;

        public CoverArtArchiveWebClient(string userAgent =null, int timeOut = 10000): base(userAgent, timeOut)
        {
        }

        public IRestRequest GetReleaseRequest(string releaseId)
        {
            return GetRequest(_ReleaseUrl).AddUrlSegment(nameof(releaseId), releaseId);
        }

        public IRestRequest GetGroupReleaseRequest(string releaseGroupId)
        {
            return GetRequest(_ReleaseGroupUrl).AddUrlSegment(nameof(releaseGroupId), releaseGroupId);
        }

        private static IRestRequest GetRequest(string url)
        {
            return new RestRequest(url).AddHeader("Accept", "application/json");
        }
    }
}
