using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace FanartTvClientTest
{
    public class FanartTvClientTest
    {
        private readonly FanartTvClient.FanartTvClient _FanartTvClient;
        public FanartTvClientTest()
        {
            _FanartTvClient = new FanartTvClient.FanartTvClient("465487c01315d40913ad11d59e544afe");
        }

        [Fact]
        public async Task GetReleaseCoverInformation_Test()
        {
            var res = await _FanartTvClient.GetReleaseCoverInformation("9ba659df-5814-32f6-b95f-02b738698e7c");
            res.Should().NotBeNull();
        }

        [Fact]
        public async Task GetArtistImageInformation_Test()
        {
            var res = await _FanartTvClient.GetArtistImageInformation("f4a31f0a-51dd-4fa7-986d-3095c40c5ed9");
            res.Should().NotBeNull();
        }
    }
}
