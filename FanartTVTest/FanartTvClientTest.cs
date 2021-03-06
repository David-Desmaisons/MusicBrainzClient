﻿using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.IO;
using Xunit.Abstractions;

namespace FanartTvClientTest
{
    public class FanartTvClientTest
    {
        private readonly FanartTvClient.FanartTvClient _FanartTvClient;
        private readonly ITestOutputHelper _Output;

        public FanartTvClientTest(ITestOutputHelper output)
        {
            _Output = output;
            _FanartTvClient = new FanartTvClient.FanartTvClient("");
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

        [Fact]
        public async Task GetLabelImageInformation_Test()
        {
            var res = await _FanartTvClient.GetLabelImageInformation("e832b688-546b-45e3-83e5-9f8db5dcde1d");
            res.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_SaveImage()
        {
            var res = await _FanartTvClient.GetReleaseCoverInformation("9ba659df-5814-32f6-b95f-02b738698e7c");
            var first = res.albumcover[0];

            var path = await _FanartTvClient.SaveImage(first, Path.GetTempPath(), "test");

            _Output.WriteLine($"Saved to {path}");
        }
    }
}
