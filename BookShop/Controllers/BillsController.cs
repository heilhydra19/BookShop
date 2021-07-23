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
    public class BillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Bills
        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.CustomerNavigation).Include(b => b.EmployeeNavigation);
            return View(bills.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CreateAt,EmployeeId,CustomerId")] Bill bill)
        {
            ModelState.Remove("EmployeeId");
            ApplicationUser currentuser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                         .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (currentuser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bill.EmployeeId = currentuser.Id;
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", bill.CustomerId);
            return View(bill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateAt,EmployeeId,CustomerId")] Bill bill)
        {
            ModelState.Remove("EmployeeId");
            ApplicationUser currentuser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                         .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (currentuser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bill.EmployeeId = currentuser.Id;
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Users, "Id", "Name", bill.CustomerId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
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
