using MusicBrainzClient.Data;
using MusicBrainzClient.Internal;
using MusicBrainzClient.Query;
using RestSharp;
using RestSharpHelper;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace MusicBrainzClient
{
    public class MusicBrainzClient : IMusicBrainzClient
    {
        private MusicBrainzWebClient _MusicBrainzWebClient;
        private CoverArtArchiveWebClient _CoverArtArchiveWebClient;

        public MusicBrainzClient(string user, string password, string userAgent=null, int timeOut=30000)
        {
            _MusicBrainzWebClient = new MusicBrainzWebClient(user, password, userAgent,  timeOut);
            _CoverArtArchiveWebClient = new CoverArtArchiveWebClient(userAgent, timeOut);
        }

        public async Task<MusicBrainzRelease> GetRelease(string id, MusicBrainzWebInclude include = MusicBrainzWebInclude.none)
        {
            return await GetRelease(id, CancellationToken.None, include);
        }

        public async Task<MusicBrainzRelease> GetRelease(string id, CancellationToken token, MusicBrainzWebInclude include = MusicBrainzWebInclude.none)
        {
            var toInclude = include.GetInclude();
            var request = _MusicBrainzWebClient.GetReleaseRequest(id, "inc", toInclude); ;
            return await _MusicBrainzWebClient.Execute<MusicBrainzRelease>(request, CancellationToken.None);
        }

        public async Task<MusicBrainzArtist> GetArtist(string id, MusicBrainzWebInclude include = MusicBrainzWebInclude.none)
        {
            return await GetArtist(id, CancellationToken.None, include);
        }

        public async Task<MusicBrainzArtist> GetArtist(string id, CancellationToken token, MusicBrainzWebInclude include = MusicBrainzWebInclude.none)
        {
            var toInclude = include.GetInclude();
            var request = _MusicBrainzWebClient.GetArtistRequest(id, "inc", toInclude); ;
            return await _MusicBrainzWebClient.Execute<MusicBrainzArtist>(request, token);
        }

        public Task<MusicBrainzCovertArtInformation> GetReleaseCoverInformation(string id)
        {
            return GetReleaseCoverInformation(id, CancellationToken.None);
        }

        public async Task<MusicBrainzCovertArtInformation> GetReleaseCoverInformation(string id, CancellationToken token)
        {
            var request = _CoverArtArchiveWebClient.GetReleaseRequest(id);
            return await _CoverArtArchiveWebClient.Execute<MusicBrainzCovertArtInformation>(request, token);
        }

        public Task DownloadImage(MusicBrainzImage image, Stream copyStream, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal)
        { 
            return DownloadImage(image, copyStream, CancellationToken.None, type);
        }

        public async Task DownloadImage(MusicBrainzImage image, Stream copyStream, CancellationToken cancellationToken, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal)
        {
            var path = image.GetImagePath(type);
            await _CoverArtArchiveWebClient.Download(path, copyStream, cancellationToken);
        }

        public Task SaveImage(MusicBrainzImage image, string path, string fileName, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal)
        {
            return SaveImage(image, path, fileName, CancellationToken.None, type);
        }

        public async Task SaveImage(MusicBrainzImage image, string path, string fileName, CancellationToken cancellationToken, MusicBrainzImageFormatType type = MusicBrainzImageFormatType.Normal)
        {
            var url = image.GetImagePath(type);
            var extension = Path.GetExtension(url);
            var fullPath = Path.Combine(path, fileName + extension);
            using (var writer = File.Create(fullPath))
            {
                await DownloadImage(image, writer, cancellationToken, type);
            }
        }

        public IEnumerable<MusicBrainzRelease> SearchReleasesEnumerable(QueryBuilder query, int? max = null)
        {
            return SearchReleases(query, max).ToEnumerable();
        }

        public IObservable<MusicBrainzRelease> SearchReleases(QueryBuilder query, int? max = null)
        {
            Func<IRestRequest> getRequest = () => _MusicBrainzWebClient.GetReleaseSearchRequest().AddQueryParameter("query", query.ToString());
            var obs = GenerateFromPaginable<MusicBrainzRelease, MusicBrainzSearchReleases>(getRequest, max);
            return (max == null) ? obs : obs.Take(max.Value);
        }

        public IEnumerable<MusicBrainzArtist> SearchArtistsEnumerable(QueryBuilder query, int? max = null)
        {
            return SearchArtists(query, max).ToEnumerable();
        }

        public IObservable<MusicBrainzArtist> SearchArtists(QueryBuilder query, int? max = null)
        {
            Func<IRestRequest> getRequest = () => _MusicBrainzWebClient.GetArtistSearchRequest().AddQueryParameter("query", query.ToString());
            return GenerateFromPaginableWithSize<MusicBrainzArtist, MusicBrainzSearchArtists>(getRequest, max);
        }

        public IEnumerable<MusicBrainzRelease> GetArtistReleasesEnumerable(string artistId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int ? max = null)
        {
            return GetArtistReleases(artistId, include, max).ToEnumerable();
        }

        public IObservable<MusicBrainzRelease> GetArtistReleases(string artistId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int ? max = null)
        {
            var toInclude = include.GetInclude();
            Func<IRestRequest> getRequest = () => _MusicBrainzWebClient.GetArtistReleasesRequest(artistId, "inc", toInclude);
            return GenerateFromPaginableWithSize<MusicBrainzRelease, MusicBrainzSearchReleases>(getRequest, max);
        }

        public IEnumerable<MusicBrainzRelease> GetLabelReleasesEnumerable(string labelId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = default(int?))
        {
            return GetLabelReleases(labelId, include, max).ToEnumerable();
        }

        public IObservable<MusicBrainzRelease> GetLabelReleases(string labelId, MusicBrainzWebInclude include = MusicBrainzWebInclude.none, int? max = default(int?))
        {
            var toInclude = include.GetInclude();
            Func<IRestRequest> getRequest = () => _MusicBrainzWebClient.GetLabelReleasesRequest(labelId, "inc", toInclude);
            return GenerateFromPaginableWithSize<MusicBrainzRelease, MusicBrainzSearchReleases>(getRequest, max);
            
        }

        private IObservable<T> GenerateFromPaginableWithSize<T, TRes>(Func<IRestRequest> requestBuilder, int? max = null) where T : MusicBrainzEntity
                       where TRes : MusicBrainzSearchResults<T>
        {
            var obs = GenerateFromPaginable<T, TRes>(requestBuilder, max);
            return (max == null) ? obs : obs.Take(max.Value);
        }

        private IObservable<T> GenerateFromPaginable<T, TRes>(Func<IRestRequest> requestBuilder, int? max = null) where T : MusicBrainzEntity
                       where TRes : MusicBrainzSearchResults<T>
        {
            var paginable = new MusicBrainzPagination()
            {
                limit = (max > 0) ? Math.Min(100, max.Value) : 25,
                offset=0
            };

            return Observable.Create<T>(async (observer, cancel) =>
            {
                TRes res;
                T[] elements = null;
                do
                {
                    cancel.ThrowIfCancellationRequested();
                    var request = requestBuilder().AddAsParameter(paginable);
                    paginable.offset+= paginable.limit;

                    res = await _MusicBrainzWebClient.Execute<TRes>(request, cancel);
                    elements = res?.GetResults();
                    if (elements == null)
                        return;

                    foreach (var result in elements)
                    {
                        cancel.ThrowIfCancellationRequested();
                        observer.OnNext(result);
                    }
                }
                while (res.offset + elements.Length != res.count);
            });
        }
    }
}
