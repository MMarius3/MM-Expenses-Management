using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using ExpensesManagementProject.DAL;
using ExpensesManagementProject.Models;
using PagedList;

namespace ExpensesManagementProject.Controllers
{
    [Authorize]
    public class IncomeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Income
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "worth_asc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            string userId = null;

            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            var incomes = from s in db.Incomes
                          where s.OwnerID == userId
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                incomes = incomes.Where(s => s.FullName.Contains(searchString)); 
            }
            if (incomes.Count() != 0)
            {
                var TotalWorth = incomes.Sum(x => x.Worth);
                ViewBag.CurrentSum = TotalWorth;
            }
            else ViewBag.CurrentSum = 0;
            switch (sortOrder)
            {
                case "name_desc":
                    incomes = incomes.OrderByDescending(s => s.Worth);
                    break;
                case "Date":
                    incomes = incomes.OrderBy(s => s.WageDate);
                    break;
                case "worth_asc":
                    incomes = incomes.OrderBy(s => s.Worth);
                    break;
                default:
                    incomes = incomes.OrderByDescending(s => s.WageDate);
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(incomes.ToPagedList(pageNumber, pageSize));
        }
        // GET: Income/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // GET: Income/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Income/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Worth,WageDate")] Income income)
        {
            if (ModelState.IsValid)
            {
                string userId = null;

                var claimsIdentity = (ClaimsIdentity)User.Identity;

                var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;
                }
                income.OwnerID = userId;
                db.Incomes.Add(income);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        // GET: Income/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Income/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Worth,WageDate")] Income income)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userId = null;

                    var claimsIdentity = (ClaimsIdentity)User.Identity;

                    var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    if (userIdClaim != null)
                    {
                        userId = userIdClaim.Value;
                    }
                    income.OwnerID = userId;//Membership.GetUser(User.Identity.Name).;
                    db.Entry(income).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(income);
        }

        // GET: Income/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Income/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Income income = db.Incomes.Find(id);
            db.Incomes.Remove(income);
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
