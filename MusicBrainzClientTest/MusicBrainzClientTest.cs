using System.Threading.Tasks;
using MusicBrainzClient.Query;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using System.Collections.Generic;
using MusicBrainzClient.Data;
using System.IO;

namespace MusicBrainzClientTest
{
    public class MusicBrainzClientTest
    {
        private readonly MusicBrainzClient.MusicBrainzClient _MusicBrainzClient;
        private readonly ITestOutputHelper _Output;

        public MusicBrainzClientTest(ITestOutputHelper output)
        {
            _MusicBrainzClient = new MusicBrainzClient.MusicBrainzClient("", "");
            _Output = output;
        }

        [Fact]
        public void Test_SearchReleases() 
        {
            var queryBuilder = new QueryBuilder().AndStrict("artist", "Ornette Coleman")
                                    .AndStrict("release", "The Shape Of Jazz To Come");
            var res = _MusicBrainzClient.SearchReleasesEnumerable(queryBuilder);
            res.Should().NotBeNull();

            Print(res);
        }

        [Fact]
        public void Test_SearchReleases2()
        {
            var queryBuilder = new QueryBuilder().AndStrict("artist", "Ornette Coleman")
                                    .And("release", "The Shape Of A Jazz To Come");
            var res = _MusicBrainzClient.SearchReleasesEnumerable(queryBuilder, 10);
            res.Should().NotBeNull();

            Print(res);
        }

        [Fact]
        public void Test_SearchReleases3()
        {
            var queryBuilder = new QueryBuilder().AndStrict("artist", "Anthony Braxton");
            var res = _MusicBrainzClient.SearchReleasesEnumerable(queryBuilder);
            res.Should().NotBeNull();

            Print(res);
        }

        [Fact]
        public void Test_GetLabelReleasesEnumerable()
        {
            var res = _MusicBrainzClient.GetLabelReleasesEnumerable("c4f2cf49-b57c-4cc1-8061-f54400704ac4", max:30);
            res.Should().NotBeNull();

            Print(res);
        }

        [Fact]
        public void Test_GetArtistReleases()
        {
            var res = _MusicBrainzClient.GetArtistReleasesEnumerable("4e5f99db-d181-4317-9124-602b776f5306");
            res.Should().NotBeNull();

            Print(res);
        }

        private void Print(IEnumerable<MusicBrainzRelease> results)
        {
            int i = 0;
            foreach (var el in results)
            {
                _Output.WriteLine($"{i++} - {el.id} - {el.title}");
            }
        }

        [Fact]
        public void Test_SearchArtits()
        {
            var queryBuilder = new QueryBuilder().AndStrict("artist", "Anthony Braxton");
            var res = _MusicBrainzClient.SearchArtistsEnumerable(queryBuilder);
            res.Should().NotBeNull();

            Print(res);
        }

        private void Print(IEnumerable<MusicBrainzArtist> results)
        {
            int i = 0;
            foreach (var el in results)
            {
                _Output.WriteLine($"{i++} - {el.id} - {el.name}");
            }
        }

        [Fact]
        public async Task Test_GetRelease()
        {
            var res = await _MusicBrainzClient.GetRelease("c778773b-0d37-454d-8402-f3d660aed486", MusicBrainzWebInclude.labels |
                MusicBrainzWebInclude.recordings| MusicBrainzWebInclude.artist_credits | MusicBrainzWebInclude.release_groups|
                MusicBrainzWebInclude.discids | MusicBrainzWebInclude.isrcs );

            res.Should().NotBeNull();

            _Output.WriteLine($"0 - {res.id} - {res.title}");
        }

        [Fact]
        public async Task Test_GetReleaseCoverInformation()
        {
            var res = await _MusicBrainzClient.GetReleaseCoverInformation("76df3287-6cda-33eb-8e9a-044b5e15ffdd");

            res.Should().NotBeNull();

            _Output.WriteLine($"0 - {res.release} - {res.images.Length}");
        }

        [Fact]
        public async Task Test_SaveImage()
        {
            var res = await _MusicBrainzClient.GetReleaseCoverInformation("76df3287-6cda-33eb-8e9a-044b5e15ffdd");
            var first = res.images[0];

            await _MusicBrainzClient.SaveImage(first, Path.GetTempPath(), "test");

            _Output.WriteLine($"0 - {res.release} - {res.images.Length}");
        }

        [Fact]
        public async Task Test_GetArtist()
        {
            await GetArtist("4e5f99db-d181-4317-9124-602b776f5306");
        }

        [Fact]
        public async Task Test_GetArtist2()
        {
            await GetArtist("83d91898-7763-47d7-b03b-b92132375c47");
        }

        private async Task GetArtist(string id)
        {
            var res = await _MusicBrainzClient.GetArtist(id);

            res.Should().NotBeNull();

            _Output.WriteLine($"0 - {res.id} - {res.name}");
        }
    }
}
