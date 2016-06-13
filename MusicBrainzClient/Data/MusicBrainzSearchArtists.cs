namespace MusicBrainzClient.Data
{
    public class MusicBrainzSearchArtists : MusicBrainzSearchResults<MusicBrainzArtist>
    {  
        public MusicBrainzArtist[] artists { get; set; }

        public override MusicBrainzArtist[] GetResults()
        {
            return artists;
        }
    }
}
