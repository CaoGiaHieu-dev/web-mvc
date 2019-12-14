using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News.Models;
using News.FW;
using PagedList;
using PagedList.Mvc;

namespace News.Areas.admin.Controllers
{
    public class menusController : BaseController
    {
        private NewsEntities db = new NewsEntities();
        public ActionResult getPagelist(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var v = (from t in db.tintucs
                     select t).OrderByDescending(a => a.datebegin);
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(v.ToPagedList(pagenumber, pagesize));
        }

        // GET: admin/menus
        public ActionResult Index()
        {
            return View(db.menus.ToList());
        }

        // GET: admin/menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: admin/menus/Create
        public ActionResult Create()
        {
            return View();
        }
        public menu getById(long id)
        {
            return db.menus.Where(x => x.id_m == id).FirstOrDefault();
        }
        // POST: admin/menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_m,name,link,meta,hide,position,datebegin")] menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                
                menu.meta = Support.ConvertToUnSign(menu.meta); //convert Tiếng Việt không dấu
                db.menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: admin/menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: admin/menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_m,name,link,meta,hide,position,datebegin")] menu menu)
        {
            menu temp = getById(menu.id_m);
            if (ModelState.IsValid)
            {
                temp.name = menu.name;
                temp.meta = menu.meta;
                temp.hide = menu.hide;
                temp.position = menu.position;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: admin/menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: admin/menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            menu menu = db.menus.Find(id);
            db.menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
