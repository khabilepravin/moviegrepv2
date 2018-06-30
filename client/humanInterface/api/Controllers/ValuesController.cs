using businessLogic;
using dataEntities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace api.Controllers
{
    public class api : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string Search(string searchCriteria)
        {
            string result = string.Empty;
            try
            {
                BusinessLogic bl = new BusinessLogic();
                List<IndexableEntity> searchResult = null;

                searchResult = bl.Search(searchCriteria, "SubtitleText");   
            
                //result = Json<
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
