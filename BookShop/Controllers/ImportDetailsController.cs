using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class ImportDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? Id)
        {
            var importDetails = db.ImportDetails.Include(i => i.BookNavigation)
                                                .Include(i => i.ImportNavigation)
                                                .Where(p => p.ImportId == Id);
            ViewBag.ImportId = Id;
            return View(importDetails.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ImportId,BookId,Count,Price")] ImportDetail importDetail, int importId)
        {
            ModelState.Remove("ImportId");
            importDetail.ImportId = importId;
            if (ModelState.IsValid)
            {
                db.ImportDetails.Add(importDetail);
                db.SaveChanges();
            }

            return RedirectToAction("Index/" + importId);
        }

        public ActionResult Delete(int? ImportId, int? BookId)
        {
            ImportDetail importDetail = db.ImportDetails.FirstOrDefault(i => i.ImportId == ImportId && i.BookId == BookId);
            db.ImportDetails.Remove(importDetail);
            db.SaveChanges();
            return RedirectToAction("Index/" + ImportId);
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
