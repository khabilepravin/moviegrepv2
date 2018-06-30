using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace core.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public string Search(string searchCriteria, string titleName)
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
            //return null;
        }
    }
}
