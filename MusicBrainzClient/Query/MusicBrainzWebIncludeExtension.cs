namespace MusicBrainzClient.Query
{
    public static class MusicBrainzWebIncludeExtension
    {
        public static string GetInclude(this MusicBrainzWebInclude include)
        {
            if (include == MusicBrainzWebInclude.none)
                return null;

            return include.ToString().Replace("_", "-").Replace(", ", "+");
        }
    }
}
