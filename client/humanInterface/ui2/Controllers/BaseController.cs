using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ui2.Custom;

namespace ui2.Controllers
{
    [CompressAttribute]
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class BaseController : Controller
    {       
    }
}