using Newtonsoft.Json;
using RateLimiter;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace RestSharpHelper
{
    public abstract class RestSharpWebClient
    {
        private const string _ErrorMessage = "Error During Request Processing";
        protected abstract string UrlBase { get; }
        protected abstract string UserAgentFallBack { get; }
        protected abstract TimeLimiter TimeLimiter { get; }

        private IRestClient _Client;
        protected IRestClient Client
        {
            get { return _Client ?? (_Client = GetClient(UrlBase, _TimeOut)); }
        }

        private string _UserAgent;
        public string UserAgent
        {
            get { return _UserAgent ?? UserAgentFallBack; }
            set { _UserAgent = value; }
        }

        private int _TimeOut;
        protected RestSharpWebClient(string userAgent=null, int timeOut = 10000) 
        {
            _TimeOut = timeOut;
            UserAgent = userAgent;
        }

        protected IRestClient GetClient(string urlBase, int timeOut = 10000)
        {
            var client = new RestClient(urlBase)
            {
                UserAgent = UserAgent,
                Timeout = timeOut
            };
            return Mature(client);
        }

        protected virtual IRestClient Mature(IRestClient client)
        {
            return client;
        }

        public async Task<T> Execute<T>(IRestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request = Mature(request);
                var response = await GetResponse(request, cancellationToken);
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch(Exception)
            {
                return default(T);
            }    
        }

        protected virtual IRestRequest Mature(IRestRequest request)
        {
            return request;
        }

        private async Task<IRestResponse> GetResponse(IRestRequest request, CancellationToken cancellationToken, IRestClient client = null)
        {
            client = client ?? Client;
            var response = await TimeLimiter.Perform(async () => await ExecuteBasic(client, request, cancellationToken), cancellationToken);

            if (response.ErrorException != null)
                throw new WebClientException(_ErrorMessage, response.ErrorException);

            return response;
        }

        public async Task<HttpStatusCode> Execute(IRestRequest request, CancellationToken cancellationToken)
        {
            var response = await GetResponse(request, cancellationToken);
            return response.StatusCode;
        }

        public async Task Download(string url, Stream copyStream, CancellationToken cancellationToken)
        {
            var client = GetClient(url, 15000);
            var request = new RestRequest(Method.GET)
            {
                ResponseWriter = (stream) => stream.CopyTo(copyStream)
            };
            await GetResponse(request, cancellationToken, client);
        }

        private static Task<IRestResponse> ExecuteBasic(IRestClient client, IRestRequest request, CancellationToken cancellationToken)
        {
            return client.ExecuteTaskAsync(request, cancellationToken);
        }
    }
}
