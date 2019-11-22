using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;
using Model.DAO;
using Model;
using News.Areas.admin.Code;
using Model.Models;
using News.Areas.Common;

namespace News.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginMD model)
        {
            var dao = new AccountDAO();
            var result = dao.loginn(model.username, model.password);
            if (result && ModelState.IsValid)
            {
                //SessionHelper.setSession(new UserSession() { username = model.username });

                var usersession = new UserLogin();
                var user = dao.getUserName(model.username);
                usersession.Username = user.Username;
                usersession.ID = user.ID;
                Session.Add(CommonConstants.User_Session,usersession);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng !");

            }
            return View(model);
        }
    }
}