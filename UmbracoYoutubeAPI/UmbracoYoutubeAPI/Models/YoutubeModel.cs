using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoYoutubeAPI.Models
{
    public class YoutubeModelList
    {
        [JsonProperty("list")]
        public List<items> Items { get; set; }
    }
    public class YoutubeModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("items")]
        public List<items> Items { get; set; }
    }
    public class items
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("snippet")]
        public snippet Snippet { get; set; }
    }
    public class snippet
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("resourceId")]
        public resource Resource { get; set; }
        [JsonProperty("thumbnails")]
        public thumbnails Thumbnails { get; set; }
    }
    public class thumbnails
    {
        [JsonProperty("standard")]
        public thumbnaildata Standard { get; set; }
    }
    public class thumbnaildata
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class resource
    {
        [JsonProperty("videoId")]
        public string VideoUrl { get; set; }
    }
}