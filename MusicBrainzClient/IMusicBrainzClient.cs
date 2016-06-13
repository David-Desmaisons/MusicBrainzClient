using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainzClient.Data;
using MusicBrainzClient.Query;
using System.IO;

namespace MusicBrainzClient
{
    public interface IMusicBrainzClient
    {
        /// <summary>
        /// Retrieve artist information from MBID
        /// </summary>
        /// <param name="id">Artist MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Artist information</returns>
        Task<MusicBrainzArtist> GetArtist(string id, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve artist information from MBID
        /// </summary>
        /// <param name="id">Artist MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Artist information</returns>
        Task<MusicBrainzArtist> GetArtist(string id, CancellationToken token, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve release information from MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Release information</returns>
        Task<MusicBrainzRelease> GetRelease(string id, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve release information from MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Release information</returns>
        Task<MusicBrainzRelease> GetRelease(string id, CancellationToken token, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve release group information from MBID
        /// </summary>
        /// <param name="id">Release group MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Release group information</returns>
        Task<MusicBrainzRelease> GetReleaseGroup(string id, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve release group information from MBID
        /// </summary>
        /// <param name="id">Release group MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <param name="include">Additional information to include</param>
        /// <returns>Release group information</returns>
        Task<MusicBrainzRelease> GetReleaseGroup(string id, CancellationToken token, MusicBrainzWebInclude include = MusicBrainzWebInclude.none);

        /// <summary>
        /// Retrieve covert information from release MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <returns>Cover Information</returns>
        Task<MusicBrainzCovertArtInformation> GetReleaseCoverInformation(string id);

        /// <summary>
        /// Retrieve covert information from release MBID
        /// </summary>
        /// <param name="id">Release MBID</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Cover Information</returns>
        Task<MusicBrainzCovertArtInformation> GetReleaseCoverInformation(string id, CancellationToken token);

        /// <summary>
        /// Retrieve observable of releases from a given artist
        /// </summary>
        /// <param name="artistId">Artist MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Corresponding releases</returns>
        IObservable<MusicBrainzRelease> GetArtistReleases(string artistId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = null);

        /// <summary>
        /// Retrieve enumerable of releases from a given artist
        /// </summary>
        /// <param name="artistId">Artist MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Corresponding releases</returns>
        IEnumerable<MusicBrainzRelease> GetArtistReleasesEnumerable(string artistId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = null);

        /// <summary>
        /// Retrieve observable of releases from a given label
        /// </summary>
        /// <param name="labelId">Label MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Corresponding releases</returns>
        IObservable<MusicBrainzRelease> GetLabelReleases(string labelId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = null);

        /// <summary>
        /// Retrieve enumerable of releases from a given label
        /// </summary>
        /// <param name="labelId">Label MBID</param>
        /// <param name="include">Additional information to include</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Corresponding releases</returns>
        IEnumerable<MusicBrainzRelease> GetLabelReleasesEnumerable(string labelId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = null);

        /// <summary>
        ///  Retrieve observable of artists from a given query
        /// </summary>
        /// <param name="query">The Corresponding query</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Found artists</returns>
        IObservable<MusicBrainzArtist> SearchArtists(QueryBuilder query, int? max = null);

        /// <summary>
        ///  Retrieve enumerable of artists from a given query
        /// </summary>
        /// <param name="query">The Corresponding query</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Found artists</returns>
        IEnumerable<MusicBrainzArtist> SearchArtistsEnumerable(QueryBuilder query, int? max = null);

        /// <summary>
        /// Retrieve observable of releases from a given query
        /// </summary>
        /// <param name="query">The Corresponding query</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Found releases</returns>
        IObservable<MusicBrainzRelease> SearchReleases(QueryBuilder query, int? max = null);

        /// <summary>
        ///  Retrieve enumerable of releases from a given query
        /// </summary>
        /// <param name="query">The Corresponding query</param>
        /// <param name="max">Number maximum of elements. If null return all elements.</param>
        /// <returns>Found releases</returns>
        IEnumerable<MusicBrainzRelease> SearchReleasesEnumerable(QueryBuilder query, int? max = null);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="copyStream">Stream where image stream will be copied</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="type">Type of image to download: thumbnail or normal</param>
        Task DownloadImage(MusicBrainzImage image, Stream copyStream, CancellationToken cancellationToken, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="copyStream">Stream where image stream will be copied</param>
        /// <param name="type">Type of image to download: thumbnail or normal</param>
        Task DownloadImage(MusicBrainzImage image, Stream copyStream, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal);

        /// <summary>
        /// Save a given image to disk.
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="path">Type of image to download: thumbnail or normal</param>
        /// <param name="fileName">Type of image to download: thumbnail or normal</param>
        /// <param name="type">Type of image to download: thumbnail or normal</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>the image stream</returns>
        Task SaveImage(MusicBrainzImage image, string path, string fileName, CancellationToken cancellationToken, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal);

        /// <summary>
        /// Download the stream corresponding to a given image
        /// </summary>
        /// <param name="image">The image to download</param>
        /// <param name="path">Type of image to download: thumbnail or normal</param>
        /// <param name="fileName">Type of image to download: thumbnail or normal</param>
        /// <param name="type">Type of image to download: thumbnail or normal</param>
        /// <returns>the image stream</returns>
        Task SaveImage(MusicBrainzImage image, string path, string fileName, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal);
    }
}