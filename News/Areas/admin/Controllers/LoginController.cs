using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;
using Model.DAO;

namespace News.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(LoginMD model )
        //{
        //    var dao = new AccountDAO();
        //    var result = dao.login(model.username, model.password);
        //    if(result && ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Wrong Id or password");

        //    }
        //    return View(model);
        //}
    }
}