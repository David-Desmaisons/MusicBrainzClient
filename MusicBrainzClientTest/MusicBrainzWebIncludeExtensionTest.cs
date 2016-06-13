using MusicBrainzClient.Query;
using Xunit;
using FluentAssertions;

namespace MusicBrainzClientTest
{
    public class MusicBrainzWebIncludeExtensionTest
    {
        [Theory]
        [InlineData(MusicBrainzWebInclude.none, null)]
        [InlineData(MusicBrainzWebInclude.aliases, "aliases")]
        [InlineData(MusicBrainzWebInclude.annotation | MusicBrainzWebInclude.aliases, "annotation+aliases")]
        [InlineData(MusicBrainzWebInclude.annotation | MusicBrainzWebInclude.aliases | MusicBrainzWebInclude.user_ratings, "annotation+aliases+user-ratings")]
        public void GetImclude_WorksAsExpected(MusicBrainzWebInclude include, string result)
        {
            include.GetInclude().Should().Be(result);
        }
    }
}
