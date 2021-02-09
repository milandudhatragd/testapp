using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.WebApi;
using UmbracoYoutubeAPI.Helper;
using UmbracoYoutubeAPI.Models;

namespace UmbracoYoutubeAPI.Controllers
{
    public class YoutubeAPIController : UmbracoApiController
    {
        // GET: YoutubeAPI
        public Response GetVideoListFromYoutube()
        {
            Response responseAPI = new Response();
            responseAPI.Data = null;
            responseAPI.StatusCode = System.Net.HttpStatusCode.NotFound;
            //Get latest data from youtube api
            List<items> items = YoutubeHelper.GetVideoListFromYoutube();
           if(items!=null)
            {
                responseAPI.Data = items;
                responseAPI.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return responseAPI;
        }
    }
}