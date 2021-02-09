using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace UmbracoYoutubeAPI.Models
{
    public class Response
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}