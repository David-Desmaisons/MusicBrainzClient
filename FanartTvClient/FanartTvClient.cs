using System.Threading;
using System.Threading.Tasks;
using FanartTvClient.Data;
using FanartTvClient.Internal;

namespace FanartTvClient
{
    public class FanartTvClient : IFanartTvClient
    {
        private readonly FanartTvWebClient _FanartTvWebClient;
        public FanartTvClient(string apiKey, string userAgent = null)
        {
            _FanartTvWebClient = new FanartTvWebClient(apiKey, userAgent);
        }

        public Task<FanartTVAlbum> GetReleaseCoverInformation(string id)
        {
            return GetReleaseCoverInformation(id, CancellationToken.None);
        }

        public async Task<FanartTVAlbum> GetReleaseCoverInformation(string id, CancellationToken token)
        {
            var request = _FanartTvWebClient.GetAlbumRequest(id);
            var allres = await _FanartTvWebClient.Execute<FanartTVImagesInfo>(request, token);
            FanartTVAlbum res = null;
            allres?.albums?.TryGetValue(id, out res);
            return res;
        }
    }
}
