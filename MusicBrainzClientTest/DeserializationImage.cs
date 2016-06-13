﻿using MusicBrainzClient.Data;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;

namespace MusicBrainzClientTest 
{
    public class DeserializationImage
    {
        private const string _Result = "{\"images\":[{\"types\":[\"Front\"],\"front\":true,\"back\":false,\"edit\":17462565,\"image\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/829521842.jpg\",\"comment\":\"\",\"approved\":true,\"id\":\"829521842\",\"thumbnails\":{\"large\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/829521842-500.jpg\",\"small\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/829521842-250.jpg\"}},{\"types\":[\"Back\"],\"front\":false,\"back\":true,\"edit\":24923554,\"image\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769317885.jpg\",\"comment\":\"\",\"approved\":true,\"id\":\"5769317885\",\"thumbnails\":{\"large\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769317885-500.jpg\",\"small\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769317885-250.jpg\"}},{\"types\":[\"Medium\"],\"front\":false,\"back\":false,\"edit\":24923552,\"image\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769316809.jpg\",\"comment\":\"\",\"approved\":true,\"id\":\"5769316809\",\"thumbnails\":{\"large\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769316809-500.jpg\",\"small\":\"http://coverartarchive.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd/5769316809-250.jpg\"}}],\"release\":\"http://musicbrainz.org/release/76df3287-6cda-33eb-8e9a-044b5e15ffdd\"}";

        [Fact]
        public void Deserialize_OK() 
        {
            var res = JsonConvert.DeserializeObject<MusicBrainzCovertArtInformation>(_Result);
            res.Should().NotBeNull();
        }
    }
}
