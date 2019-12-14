using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;
using News.Controllers;
using PagedList;
using PagedList.Mvc;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        NewsEntities _db = new NewsEntities();
        //
        // GET: /Category/
        public ActionResult getPagelist(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var v = (from t in _db.tintucs
                     select t).OrderByDescending(a => a.datebegin);
            int pagesize = 8;
            int pagenumber = (page ?? 1);
            return PartialView(v.ToPagedList(pagenumber, pagesize));
        }

        public ActionResult Index(string meta)
        {
                var v = from t in _db.menus
                        where t.meta == meta
                        select t;
                return View(v.FirstOrDefault());
        }
        //public ActionResult getProduct(int id_m)
        //{
        //    var v = (from t in _db.tintucs
        //             where t.hide == false && t.id_m == id_m
        //             orderby t.datebegin descending
        //             select t);
        //    return PartialView(v.ToList());
        //}
        public ActionResult getProduct(int id_m, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var v = (from t in _db.tintucs
                     where t.hide == false && t.id_m == id_m
                     select t).OrderByDescending(a => a.datebegin);
            int pagesize = 8;
            int pagenumber = (page ?? 1); ;
            return PartialView(v.ToPagedList(pagenumber, pagesize));
        }

        public ActionResult getDetail(int id)
        {
            var v = from t in _db.tintucs
                    where t.id == id
                    select t;
            return PartialView(v.ToList());
        }
	}
}