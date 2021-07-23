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
    public class EmployeesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public EmployeesController()
        {
        }

        public EmployeesController(ApplicationUserManager userManager)
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
            return View(db.Users.Where(u => u.Roles.Any(r => r.RoleId == db.Roles.FirstOrDefault(p => p.Name.ToString() == "Employee").Id)).ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.Users.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ApplicationUser employee)
        {
            if (ModelState.IsValid)
            {
                RegisterViewModel model = new RegisterViewModel { Email = employee.Email, Name = employee.Name, Address = employee.Address, Phone = employee.Phone, Password = employee.PasswordHash, ConfirmPassword = employee.PasswordHash };
                employee = new ApplicationUser { UserName = model.Email, Name = model.Name, Address = model.Address, Phone = model.Phone, Email = model.Email };
                var result = await UserManager.CreateAsync(employee, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(employee.Id, "Employee");
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            ApplicationUser customer = db.Users.Find(id);
            db.Users.Remove(customer);
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
