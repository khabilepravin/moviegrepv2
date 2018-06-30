using businessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace api.Controllers
{
    public class SearchController : ApiController
    {   
        public IHttpActionResult GetRandomQuote(int i)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            
            var model = businessLogic.GetRandomQuote("");

            return Ok(Json(model));
        }
    }
}