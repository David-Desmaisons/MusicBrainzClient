using System;

namespace MusicBrainzClient.Query
{
    [Flags]
    public enum MusicBrainzWebInclude : ulong
    {
        none=0,
        annotation=1,
        labels=2,
        recordings=4,
        release_groups=8,
        media=16,
        discids=32,
        isrcs=64,
        artist_credits=128,
        aliases=256,
        ratings=1024,
        user_ratings=2048,
        various_artists=4096
    }
}
