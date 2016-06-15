using FanartTvClient.Data;
using System.Threading;
using System.Threading.Tasks;

namespace FanartTvClient 
{
    public interface IFanartTvClient 
    {
        /// <summary>
        /// Retrieve covert information from release MBID
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
    }
}