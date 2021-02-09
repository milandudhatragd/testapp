using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using UmbracoYoutubeAPI.Models;

namespace UmbracoYoutubeAPI.Helper
{
    public static class YoutubeHelper
    {
        private const string URL = "https://www.googleapis.com/youtube/v3/playlistItems";
        private static string urlParameters = "?part=snippet&maxResults=10&playlistId=" + ConfigurationManager.AppSettings["Youtube.PlaylistID"] + "&key=" + ConfigurationManager.AppSettings["Youtube.ApiKey"];

        public static List<items> GetVideoListFromYoutube()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                YoutubeModel data = null;
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    data = response.Content.ReadAsAsync<YoutubeModel>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                }

                client.Dispose();
                return data?.Items;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}