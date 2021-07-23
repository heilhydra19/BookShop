using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using Microsoft.AspNet.Identity.Owin;

namespace BookShop.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public CustomersController()
        {
        }

        public CustomersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View(db.Users.Where(u => u.Roles.Any(r => r.RoleId == db.Roles.FirstOrDefault(p => p.Name.ToString() == "Customer").Id)).ToList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationUser customer)
        {
            if (ModelState.IsValid)
            {
                RegisterViewModel model = new RegisterViewModel { Email = customer.Email, Name = customer.Name, Address = customer.Address, Phone = customer.Phone, Password = customer.PasswordHash, ConfirmPassword = customer.PasswordHash };
                customer = new ApplicationUser { UserName = model.Email, Name = model.Name, Address = model.Address, Phone = model.Phone, Email = model.Email };
                var result = await UserManager.CreateAsync(customer, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(customer.Id, "Customer");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            ApplicationUser customer = db.Users.Find(id);
            db.Users.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index"); ;
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
