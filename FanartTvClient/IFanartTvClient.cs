using FanartTvClient.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FanartTvClient 
{
    public interface IFanartTvClient 
    {
        /// <summary>
        /// Retrieve cover information from release MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <returns>Cover Information</returns>
        Task<FanartTVAlbum> GetReleaseCoverInformation(string id);

        /// <summary>
        /// Retrieve covert information from release MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Cover Information</returns>
        Task<FanartTVAlbum> GetReleaseCoverInformation(string id, CancellationToken token);

        /// <summary>
        /// Retrieve artist image information from artist MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <returns>Artist image information</returns>
        Task<FanartTVArtistImagesInfo> GetArtistImageInformation(string id);

        /// <summary>
        /// Retrieve artist image information from artist MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Artist image information</returns>
        Task<FanartTVArtistImagesInfo> GetArtistImageInformation(string id, CancellationToken token);

        /// <summary>
        /// Retrieve label image information from label MBID
        /// </summary>
        /// <param name="id">Label MBID</param>
        /// <returns>Label image information</returns>
        Task<FanartTVLabelImagesInfo> GetLabelImageInformation(string id);

        /// <summary>
        /// Retrieve label image information from label MBID
        /// </summary>
        /// <param name="id">Label MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Label image information</returns>
        Task<FanartTVLabelImagesInfo> GetLabelImageInformation(string id, CancellationToken token);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="copyStream">Stream where image stream will be copied</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        Task DownloadImage(FanartTVImageInfo image, Stream copyStream, CancellationToken cancellationToken);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="copyStream">Stream where image stream will be copied</param>
        Task DownloadImage(FanartTVImageInfo image, Stream copyStream);

        /// <summary>
        /// Save a given image to disk.
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="path">Type of image to download: thumbnail or normal</param>
        /// <param name="fileName">Type of image to download: thumbnail or normal</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>the image stream</returns>
        Task SaveImage(FanartTVImageInfo image, string path, string fileName, CancellationToken cancellationToken);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="path">Type of image to download: thumbnail or normal</param>
        /// <param name="fileName">Type of image to download: thumbnail or normal</param>
        /// <returns>the image stream</returns>
        Task SaveImage(FanartTVImageInfo image, string path, string fileName);

    }
}