namespace MusicBrainzClient.Data
{
    public class MusicBrainzImage
    {
        public int edit { get; set; }
        public string id { get; set; }
        public string image { get; set; }
        public MusicBrainzThumbnails thumbnails { get; set; }
        public string comment { get; set; }
        public bool approved { get; set; }
        public bool front { get; set; }
        public string[] types { get; set; }
        public bool back { get; set; }

        public string GetImagePath( MusicBrainzImageFormatType type)
        {
            switch (type)
            {
                case MusicBrainzImageFormatType.Normal:
                    return image;

                case MusicBrainzImageFormatType.ThumbnailLarge:
                    return thumbnails?.large;

                case MusicBrainzImageFormatType.ThumbnailSmall:
                    return thumbnails?.small;
            }

            return null;
        }
    }
}