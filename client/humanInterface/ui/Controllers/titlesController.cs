using businessLogic;
using dataEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace ui.Controllers
{
    public class titlesController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitTitle(Title submittedTitle)
        {
            ActionResult actionResult = null;
            TextReader reader = null;

            try
            {
                if(submittedTitle.AdminPass == "Shutthefuckupdonny")
                { 
                    BusinessLogic bizLogic = new BusinessLogic();
                    TitleSubtitle titleSubtitle = null;
                    if (submittedTitle.SubtitleFile != null)
                    {
                        titleSubtitle = new TitleSubtitle();

                        reader = new StreamReader(submittedTitle.SubtitleFile.InputStream);
                        titleSubtitle.SubtitleText = reader.ReadToEnd();
                    }

                    int insertedTitleId = bizLogic.SubmitTitle(submittedTitle, titleSubtitle);
                    actionResult = View("PostProcess", insertedTitleId);
                }
                else
                {
                    throw new Exception("Unauthorized");
                }
            }
            catch(Exception ex)            
            {
                HandleErrorInfo errorInfo = new HandleErrorInfo(ex, "titles", "SubmitTitle");
                actionResult = View("Error", errorInfo);
            }
            finally
            {
                if(reader != null) { reader.Close(); }
            }

            return actionResult;
        }

        [HttpGet]
        public ActionResult ParseTitle(int titleId)
        {
            ActionResult actionResult = null;
            try
            {
                BusinessLogic bl = new BusinessLogic();
                bl.ParseTitle(titleId);
                actionResult = new ContentResult() { Content = string.Empty };
            }
            catch (Exception ex)
            {
                HandleErrorInfo errorInfo = new HandleErrorInfo(ex, "titles", "ParseTitle");
                actionResult = View("Error", errorInfo);
            }

            return actionResult;
        }

        [HttpGet]
        public ActionResult IndexTitle(int titleId)
        {
            ActionResult actionResult = null;

            try
            {
                BusinessLogic bl = new BusinessLogic();
                bl.IndexTitle(titleId);
                actionResult = new ContentResult() { Content = string.Empty };
            }
            catch (Exception ex)
            {
                HandleErrorInfo errorInfo = new HandleErrorInfo(ex, "titles", "IndexTitle");
                actionResult = View("Error", errorInfo);
            }

            return actionResult;
        }

        //[HttpGet]
        //public ActionResult Search(string searchCriteria, string titleName)
        //{
        //    ActionResult actionResult = null;
        //    try
        //    {
        //        BusinessLogic bl = new BusinessLogic();
        //        List<IndexableEntity> searchResult = null;
        //        string userId = User.Identity.IsAuthenticated ? User.Identity.GetUserId() : string.Empty;

        //        if (string.IsNullOrWhiteSpace(titleName))
        //        {
        //            searchResult = bl.Search(searchCriteria, "SubtitleText", userId);
        //        }
        //        else
        //        {
        //            Dictionary<string, string> searchTerms = new Dictionary<string, string>();
        //            searchTerms.Add("SubtitleText", searchCriteria);
        //            searchTerms.Add("TitleName", titleName);

        //            searchResult = bl.Search(searchTerms, userId);
        //        }

        //        actionResult = PartialView("SearchResult", searchResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleErrorInfo errorInfo = new HandleErrorInfo(ex, "titles", "Search");
        //        actionResult = View("Error", errorInfo);
        //    }

        //    return actionResult;
        //}

        public ActionResult Analysis()
        {
            return View();
        }

        public ActionResult Explore()
        {
            return View();
        }

        public ActionResult reparseAndReIndexEverything()
        {
            BusinessLogic bl = new BusinessLogic();
            bl.ParseAndReIndexAll();

            return new ContentResult();
        }

        [HttpGet]
        public ActionResult titleAutoSuggestData()
        {
            ActionResult result = null;

            BusinessLogic bl = new BusinessLogic();

            string alltitles = bl.TitlesGetAllJson();

            if (alltitles != null)
            {
                result = new ContentResult() { Content = alltitles };
            }

            return result;
        }

        public ActionResult RateText(int rating, int textId, int ratingId)
        {
            ActionResult result = null;

            if (User.Identity.IsAuthenticated)
            {   
                UserFavorite userFavorite = new UserFavorite() 
                {
                    Rating = rating,
                    SubtitleTextId = textId,
                    UserIdentification = User.Identity.GetUserId(),
                    IdentificationSource = User.Identity.AuthenticationType,
                    UserFavoriteId = ratingId
                };

                BusinessLogic logic = new BusinessLogic();
                long recordId = logic.AddUpdateUserFavorite(userFavorite);

                result = new ContentResult() { Content = recordId.ToString() };
            }

            return result;
        }
    }
}