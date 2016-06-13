using System;
using System.Net;
using RateLimiter;
using RestSharp;
using RestSharp.Authenticators;
using RestSharpHelper;

namespace MusicBrainzClient.Internal
{
    internal class MusicBrainzWebClient : RestSharpWebClient
    {
        private const string _DiscUrl = "discid";
        private const string _SearchReleaseUrl = "release";
        private const string _ReleaseUrl = "release/{id}";
        private const string _SearchReleaseGroupUrl = "release-group";
        private const string _ReleaseGroupUrl = "release-group/{id}";
        private const string _ArtistUrl = "artist/{id}";
        private const string _ArtistReleaseUrl = "release?artist={id}";
        private const string _SearchArtistUrl = "artist";
        private const string _LabelReleaseUrl = "release?label={id}";
        private readonly string _User;
        private readonly string _Password;

        protected override string UrlBase => "http://musicbrainz.org/ws/2";

        protected override string UserAgentFallBack=> @"MuzicBrainzClient https://github.com/David-Desmaisons/MuzicBrainzClient";

        protected override TimeLimiter TimeLimiter => MusicBrainzRateLimiter.MuzicBrainzTimeLimiter;

        public MusicBrainzWebClient(string user, string password, string userAgent =null, int timeOut = 10000): base(userAgent, timeOut)
        {
            _User = user;
            _Password = password;
        }

        public IRestRequest GetArtistReleasesRequest(string artistId, string option, string value)
        {
            return GetEntityRequest(_ArtistReleaseUrl, artistId, option, value);
        }

        public IRestRequest GetArtistRequest(string artistId, string option, string value)
        {
            return GetEntityRequest(_ArtistUrl, artistId, option, value);
        }

        public IRestRequest GetLabelReleasesRequest(string labelId, string option, string value)
        {
            return GetEntityRequest(_LabelReleaseUrl, labelId, option, value);
        }

        public IRestRequest GetReleaseGroupRequest(string id, string option, string value)
        {
            return GetEntityRequest(_ReleaseGroupUrl, id, option, value);
        }

        public IRestRequest GetReleaseRequest(string releaseId, string option, string value)
        {
            return GetEntityRequest(_ReleaseUrl, releaseId, option, value);
        }

        private static IRestRequest GetEntityRequest(string baseUrl, string id, string option, string value)
        {
            var request = (value == null) ? GetRequest(baseUrl) : GetRequest($"{baseUrl}?{option}={value}");
            return request.AddUrlSegment(nameof(id), id);
        }

        public IRestRequest GetReleaseSearchRequest() 
        {
            return GetRequest(_SearchReleaseUrl);
        }

        public IRestRequest GetArtistSearchRequest()
        {
            return GetRequest(_SearchArtistUrl);
        }

        private static IRestRequest GetRequest(string url)
        {
            return new RestRequest(url).AddHeader("Accept", "application/json");
        }

        protected override IRestClient Mature(IRestClient client)
        {
            var credentialCache = new CredentialCache();
            credentialCache.Add(new Uri(UrlBase), "Digest", new NetworkCredential(_User, _Password));
            client.Authenticator = new NtlmAuthenticator(credentialCache);
            return client;
        }

        protected override IRestRequest Mature(IRestRequest request)
        {
            return request.AddQueryParameter("fmt", "json");
        }
    }
}
