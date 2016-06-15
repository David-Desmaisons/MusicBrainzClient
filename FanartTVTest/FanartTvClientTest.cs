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
            _FanartTvClient = new FanartTvClient.FanartTvClient("");
        }

        [Fact]
        public async Task GetReleaseCoverInformation_Test()
        {
            var res = await _FanartTvClient.GetReleaseCoverInformation("9ba659df-5814-32f6-b95f-02b738698e7c");
            res.Should().NotBeNull();
        }
    }
}
