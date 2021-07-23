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
    public class BillDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BillDetails
        public ActionResult Index(int? Id)
        {
            var billDetails = db.BillDetails.Include(b => b.BillNavigation).Include(b => b.BookNavigation)
                                            .Where(p => p.BillId == Id);
            ViewBag.BillId = Id;
            return View(billDetails.ToList());
        }

        // GET: BillDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "BookId,BillId,Count")] BillDetail billDetail, int billId)
        {
            ModelState.Remove("BillId");
            billDetail.BillId = billId;
            if (ModelState.IsValid)
            {
                db.BillDetails.Add(billDetail);
                db.SaveChanges();
            }

            return RedirectToAction("Index/" + billId);
        }

        public ActionResult Delete(int? BillId, int? BookId)
        {
            BillDetail billDetail = db.BillDetails.FirstOrDefault(b => b.BillId == BillId && b.BookId == BookId);
            db.BillDetails.Remove(billDetail);
            db.SaveChanges();
            return RedirectToAction("Index/" + BillId);
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
