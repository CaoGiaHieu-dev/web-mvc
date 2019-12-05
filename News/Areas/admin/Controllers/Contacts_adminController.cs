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
    public class Contacts_adminController : BaseController
    {
        private NewsEntities db = new NewsEntities();

        // GET: admin/Contacts_admin
        public ActionResult getPagelist(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            var v = (from t in db.Contacts
                     select t).OrderByDescending(a => a.ID_contact);
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(v.ToPagedList(pagenumber, pagesize));
        }
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.menu);
            return View(contacts.ToList());
        }

        // GET: admin/Contacts_admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: admin/Contacts_admin/Create
        public ActionResult Create()
        {
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name");
            return View();
        }

        // POST: admin/Contacts_admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_contact,name,img,description,detail,datebegin,id_m")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", contact.id_m);
            return View(contact);
        }

        // GET: admin/Contacts_admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", contact.id_m);
            return View(contact);
        }

        // POST: admin/Contacts_admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_contact,name,img,description,detail,datebegin,id_m")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_m = new SelectList(db.menus, "id_m", "name", contact.id_m);
            return View(contact);
        }

        // GET: admin/Contacts_admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: admin/Contacts_admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
