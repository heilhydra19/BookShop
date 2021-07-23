using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BookShop.Controllers
{
    public class ImportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var imports = db.Imports.Include(i => i.EmployeeNavigation).Include(i => i.SupplierNavigation);
            return View(imports.ToList());
        }

        // POST: Imports/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CreateAt,EmployeeId,SupplierId")] Import import)
        {
            ModelState.Remove("EmployeeId");
            ApplicationUser currentuser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                         .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (currentuser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            import.EmployeeId = currentuser.Id;
            if (ModelState.IsValid)
            {
                db.Imports.Add(import);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(import);
        }

        // GET: Imports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Import import = db.Imports.Find(id);
            if (import == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", import.SupplierId);
            return View(import);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateAt,EmployeeId,CustomerId")] Import import)
        {
            ModelState.Remove("EmployeeId");
            ApplicationUser currentuser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                         .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (currentuser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            import.EmployeeId = currentuser.Id;
            if (ModelState.IsValid)
            {
                db.Entry(import).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Users, "Id", "Name", import.SupplierId);
            return View(import);
        }

        // GET: Imports/Delete/5
        public ActionResult Delete(int? id)
        {
            Import import = db.Imports.Find(id);
            db.Imports.Remove(import);
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
