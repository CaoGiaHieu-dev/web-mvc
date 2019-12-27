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
    public class tintucsController : BaseController
    {

        // GET: admin/tintucs
        public ActionResult getPagelist(int? page)
        {
            if(page == null)
            {
                page = 1;
            }
            var v = (from t in db.tintucs
                     select t).OrderByDescending(a => a.datebegin);
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(v.ToPagedList(pagenumber, pagesize));
        }



        public ActionResult Index()
        {
            var tintuc = db.tintucs.Include(t => t.menu);
            return View(tintuc);
        }

        // GET: admin/tintucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: admin/tintucs/Create
        public ActionResult Create()
        {
            var v = from t in db.menus
                    where t.id_m != 1
                    select t;
            ViewBag.id_m = new SelectList(v, "id_m", "name");
            return View();
        }

        // POST: admin/tintucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,img,description,link,detail,meta,hide,position,datebegin,id_m")] tintuc tintuc, HttpPostedFileBase img)
        {
            //if (ModelState.IsValid)
            //{
            //    db.tintucs.Add(tintuc);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.id_m = new SelectList(db.menus, "id_m", "name", tintuc.id_m);
            //return View(tintuc);
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img"), filename);
                        img.SaveAs(path);
                        tintuc.img = filename; //Lưu ý
                    }
                    else
                    {
                        tintuc.img = "icon.png";
                    }
                    tintuc.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    tintuc.meta = Support.ConvertToUnSign(tintuc.meta); //convert Tiếng Việt không dấu
                    db.tintucs.Add(tintuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", tintuc.id_m);
            return View(tintuc);
        }

        // GET: admin/tintucs/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", tintuc.id_m);
            return View(tintuc);
        }
        public tintuc getById(long id)
        {
            return db.tintucs.Where(x => x.id == id).FirstOrDefault();

        }
        // POST: admin/tintucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,img,description,link,detail,meta,hide,position,datebegin,id_m")] tintuc tintuc, HttpPostedFileBase img)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tintuc).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.id_m = new SelectList(db.menus, "id_m", "name", tintuc.id_m);
            //return View(tintuc);
            try
            {
                var path = "";
                var filename = "";
                tintuc temp = getById(tintuc.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.name = tintuc.name;
                    temp.description = tintuc.description;
                    temp.detail = tintuc.detail;
                    temp.meta = Support.ConvertToUnSign(tintuc.meta); //convert Tiếng Việt không dấu
                    temp.hide = tintuc.hide;
                    temp.position = tintuc.position;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", tintuc.id_m);
            return View(tintuc);
        }
        // GET: admin/tintucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: admin/tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tintuc tintuc = db.tintucs.Find(id);
            db.tintucs.Remove(tintuc);
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
