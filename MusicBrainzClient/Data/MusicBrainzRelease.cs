namespace MusicBrainzClient.Data
{
    public class MusicBrainzSearchReleases : MusicBrainzSearchResults<MusicBrainzRelease>
    {  
        public MusicBrainzRelease[] releases { get; set; }

        public override MusicBrainzRelease[] GetResults()
        {
            return releases;
        }
    }
}
