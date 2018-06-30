using businessLogic;
using dataEntities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ui.Controllers
{
    public class QuotesController : BaseController
    {
        public ActionResult RandomText()
        {
            ActionResult result = null;

            BusinessLogic businessLogic = new BusinessLogic();

            string userId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : string.Empty;

            var model = businessLogic.GetRandomQuote(userId);

            result = PartialView("_RandomText", model);

            return result;
        }

        public ActionResult Details(int id, string quote, string moreOrLess)
        {
            BusinessLogic bl = new BusinessLogic();

            List<IndexableEntity> subtitlesAdjacent = bl.SubtitlesGetAdjacent(id, 3, 3);
            ViewData["currentId"] = id;
            return View(subtitlesAdjacent);
        }

        public ActionResult GetTitlePercent(long id, double currentTime)
        {
            ActionResult result = null;
            BusinessLogic businessLogic = new BusinessLogic();

            int percent = businessLogic.GetCurrentTimePercent(id, currentTime);

            result = new ContentResult() { Content = percent.ToString() };

            return result;
        }

        [HttpGet]
        public ActionResult Search(string searchCriteria, string titleName)
        {
            ActionResult actionResult = null;
            try
            {
                BusinessLogic bl = new BusinessLogic();
                List<IndexableEntity> searchResult = null;
                string userId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : string.Empty;

                if (string.IsNullOrWhiteSpace(titleName))
                {
                    searchResult = bl.Search(searchCriteria, "SubtitleText", userId);
                }
                else
                {
                    Dictionary<string, string> searchTerms = new Dictionary<string, string>();
                    searchTerms.Add("SubtitleText", searchCriteria);
                    searchTerms.Add("TitleName", titleName);

                    searchResult = bl.Search(searchTerms, userId);
                }

                actionResult = PartialView("SearchResult", searchResult);
            }
            catch (Exception ex)
            {
                HandleErrorInfo errorInfo = new HandleErrorInfo(ex, "titles", "Search");
                actionResult = View("Error", errorInfo);
            }

            return actionResult;
        }

        [HttpPost]
        public ActionResult PostXML(string xml)
        {
            return new ContentResult() { Content = "All ok" };
        }
    }
}