using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ui.Custom;

namespace ui.Controllers
{
    [CompressAttribute]
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class BaseController : Controller
    {       
    }
}