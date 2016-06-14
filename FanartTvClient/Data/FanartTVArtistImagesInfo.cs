namespace FanartTvClient.Data 
{
    public class FanartTVArtistImagesInfo : FanartTVImagesInfo
    {
        public FanartTVImageInfo[] artistbackground { get; set; }
        public FanartTVImageInfo[] artistthumb { get; set; }
        public FanartTVImageInfo[] musiclogo { get; set; }
        public FanartTVImageInfo[] hdmusiclogo { get; set; }
        public FanartTVImageInfo[] musicbanner { get; set; }
    }
}
