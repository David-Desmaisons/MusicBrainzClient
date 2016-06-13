using System;

namespace MusicBrainzClient.Data 
{
    public abstract class MusicBrainzSearchResults<T>
    {
        public DateTime? created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }

        public abstract T[] GetResults();
    }
}
