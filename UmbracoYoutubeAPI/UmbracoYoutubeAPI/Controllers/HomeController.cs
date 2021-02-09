using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web;
using Umbraco.Core.Models.PublishedContent;
using Newtonsoft.Json;
using UmbracoYoutubeAPI.Models;
using Umbraco.Core.Models;
using UmbracoYoutubeAPI.Helper;

namespace UmbracoYoutubeAPI.Controllers
{
    public class HomeController : SurfaceController
    {
        public ActionResult Home()
        {
            IPublishedContent home = CurrentPage.AncestorOrSelf(1);
            YoutubeModelList youtubeModelList = new YoutubeModelList();
            //Get latest data from youtube api
            youtubeModelList.Items= YoutubeHelper.GetVideoListFromYoutube();
            if(youtubeModelList.Items==null)
            {
                TempData["message"] = "Something went wrong";
                return RedirectToUmbracoPage(CurrentPage.Id);
            }
            //Get existing content
            IContent content= Services.ContentService.GetById(home.Id);
            var obj = JsonConvert.SerializeObject(youtubeModelList);
            content.SetValue("Youtube",obj);
            //Update existing content
            Services.ContentService.SaveAndPublish(content);
            return RedirectToUmbracoPage(CurrentPage.Id);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}