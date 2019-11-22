using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;
using PagedList;
using PagedList.Mvc;
using News.Controllers;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        NewsEntities _db = new NewsEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult getMenu()
        {
            ViewBag.meta = "khoa";
            var v = from t in _db.menus
                    where t.hide == false
                    orderby t.datebegin ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getMenufornews( int id_a)
        {
            var v = (from t in _db.tintucs
                    where t.hide == false && t.id_m ==id_a
                    orderby t.position ascending
                    select t).Take(4) ;
            return PartialView(v.ToList());
        }

        public ActionResult getMenuDesktop()
        {
            ViewBag.meta = "khoa";
            var v = from t in _db.menus
                    where t.hide == false
                    orderby t.datebegin ascending
                    select t;
            return PartialView(v.ToList());

        }

        public ActionResult getCategory()
        {
            ViewBag.meta = "khoa";
            var v = from t in _db.menus
                    where t.hide == false && t.id_m != 1
                    orderby t.position ascending
                    select t;
            return PartialView(v.ToList());

        }

        public ActionResult getNewFooter ()
        {
            ViewBag.meta = "tin-tuc";
            var v = (from t in _db.tintucs
                     where t.hide == false
                     orderby t.datebegin descending
                     select t).Take(3);
            return PartialView(v.ToArray());

        }
        public ActionResult getNewTrending ()
        {
            ViewBag.meta = "tin-tuc";
            var v = (from t in _db.tintucs
                     where t.hide == false
                     orderby t.datebegin descending
                     select t).Take(3);
            return PartialView(v.ToArray());
        }

        public ActionResult getNewhomepage()
        {
            ViewBag.meta = "tin-tuc";
            var v = (from t in _db.tintucs
                     where t.hide == false
                     orderby t.datebegin descending
                     select t).Take(6);
            return PartialView(v.ToArray());
        }

        public ActionResult getCategoryhomepage()
        {
            ViewBag.meta = "khoa";
            var v = from t in _db.menus
                    where t.hide == false && t.id_m != 1
                    orderby t.position ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getNewforobj(int id_a)
        {
            ViewBag.meta = "tin-tuc";
            var v = (from t in _db.tintucs
                     where t.hide == false && t.id_m==id_a
                     orderby t.datebegin descending
                     select t).Take(3);
            return PartialView(v.ToList());
        }
        
        public ActionResult getTag()
        {
            ViewBag.meta = "khoa";
            var v = from t in _db.menus
                    where t.hide == false && t.id_m != 1
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getNewsforlayout()
        {
            ViewBag.meta = "tin-tuc";
            var v = (from t in _db.tintucs
                     where t.hide == false
                     orderby t.datebegin descending
                     select t).Take(5);
            return PartialView(v.ToList());
        }

        public ActionResult Search(string key)
        {
            ViewBag.meta = key;
            return View();
        }

        public ActionResult getSearch(string key,int? page)
        {
            ViewBag.meta = key;
            if (page == null)
            {
                page = 1;
            }
            var v = from t in _db.tintucs
                    orderby t.datebegin descending
                    select t;
            if(!string.IsNullOrEmpty(key))
            {
                v = v.Where(s => s.description.Contains(key)).OrderByDescending(a=>a.datebegin);
            }
            int pagesize = 8;
            int pagenumber = (page ?? 1); 
            return PartialView(v.ToPagedList(pagenumber, pagesize));
        }

    }
}