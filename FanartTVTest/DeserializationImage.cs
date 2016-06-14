using FanartTvClient.Data;
using Newtonsoft.Json;
using FluentAssertions;
using Xunit;

namespace FanartTvClientTest
{
    public class DeserializationImage
    {
        private const string _Result = "{ \"name\": \"Evanescence\",    \"mbid_id\": \"f4a31f0a-51dd-4fa7-986d-3095c40c5ed9\", \"albums\": { \"9ba659df-5814-32f6-b95f-02b738698e7c\": { \"cdart\": [ { \"id\": \"12420\", \"url\": \"http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/cdart/anywhere-but-home-4e9a1074d0999.png\", \"likes\": \"0\", \"disc\": \"1\", \"size\": \"1000\" } ], \"albumcover\": [ { \"id\": \"116236\", \"url\": \"http://assets.fanart.tv/fanart/music/f4a31f0a-51dd-4fa7-986d-3095c40c5ed9/albumcover/anywhere-but-home-532dbf4618e4b.jpg\", \"likes\": \"0\" } ] } } }";

        [Fact]
        public void Deserialize_OK() 
        {
            var res = JsonConvert.DeserializeObject<FanartTVImageInfo>(_Result);
            res.Should().NotBeNull();
        }
    }
}
