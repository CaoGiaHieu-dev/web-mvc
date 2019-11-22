using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using News.Areas.Common;

namespace News.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: admin/Base
        protected override void OnActionExecuting(ActionExecutingContext fillterContext)
        {
            var session =(UserLogin) Session[CommonConstants.User_Session];
            if(session == null)
            {
                fillterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuting(fillterContext);
        }
    }
}