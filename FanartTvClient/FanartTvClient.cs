using System.IO;
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

        public Task<FanartTVArtistImagesInfo> GetArtistImageInformation(string id)
        {
            return GetArtistImageInformation(id, CancellationToken.None);
        }

        public async Task<FanartTVArtistImagesInfo> GetArtistImageInformation(string id, CancellationToken token)
        {
            var request = _FanartTvWebClient.GetArtistRequest(id);
            return await _FanartTvWebClient.Execute<FanartTVArtistImagesInfo>(request, token);
        }

        public Task<FanartTVLabelImagesInfo> GetLabelImageInformation(string id)
        {
            return GetLabelImageInformation(id, CancellationToken.None);
        }

        public async Task<FanartTVLabelImagesInfo> GetLabelImageInformation(string id, CancellationToken token)
        {
            var request = _FanartTvWebClient.GetLabelRequest(id);
            return await _FanartTvWebClient.Execute<FanartTVLabelImagesInfo>(request, token);
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

        public Task DownloadImage(FanartTVImageInfo image, Stream copyStream)
        {
            return DownloadImage(image, copyStream, CancellationToken.None);
        }

        public async Task DownloadImage(FanartTVImageInfo image, Stream copyStream, CancellationToken cancellationToken)
        {
            var path = image.url;
            await _FanartTvWebClient.Download(path, copyStream, cancellationToken);
        }

        public Task SaveImage(FanartTVImageInfo image, string path, string fileName)
        {
            return SaveImage(image, path, fileName, CancellationToken.None);
        }

        public async Task SaveImage(FanartTVImageInfo image, string path, string fileName, CancellationToken cancellationToken)
        {
            var extension = Path.GetExtension(image.url);
            var fullPath = Path.Combine(path, fileName + extension);
            using (var writer = File.Create(fullPath))
            {
                await DownloadImage(image, writer, cancellationToken);
            }
        }
    }
}
