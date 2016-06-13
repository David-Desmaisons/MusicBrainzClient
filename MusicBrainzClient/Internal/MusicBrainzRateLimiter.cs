using RateLimiter;
using System;

namespace MusicBrainzClient.Internal
{
    public static class MusicBrainzRateLimiter
    {
        internal static TimeLimiter MuzicBrainzTimeLimiter { get; set; }

        static MusicBrainzRateLimiter()
        {
            MuzicBrainzTimeLimiter = TimeLimiter.GetFromMaxCountByInterval(1, TimeSpan.FromSeconds(1));
        }
    }
}
