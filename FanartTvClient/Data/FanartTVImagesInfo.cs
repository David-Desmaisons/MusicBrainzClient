﻿using System.Collections.Generic;

namespace FanartTvClient.Data 
{
    public class FanartTVImagesInfo 
    {
        public string name { get; set; }
        public string mbid_id { get; set; }
        public Dictionary<string,FanartTVAlbum> albums { get; set; }
    }
}
