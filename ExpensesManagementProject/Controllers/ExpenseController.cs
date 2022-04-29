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
    public class ExpenseController : Controller
    {
        private ProjectContext db = new ProjectContext();
        // GET: Expense
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page 
                                                                        //DateTime DateIn, DateTime DateOut
                                                                                                            )
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "cost_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "cost_asc" : "Date";
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
            var expenses = from s in db.Expenses
                           where s.OwnerID == userId
                           select s;
            var TotalCost = 0;
            if (expenses.Count() != 0)
            {
                TotalCost = expenses.Sum(x => x.Cost);
            }
            var incomes = from s in db.Incomes
                          where s.OwnerID == userId
                          select s;
            var TotalWorth = 0;
            if (incomes.Count() != 0)
            {
                TotalWorth = incomes.Sum(x => x.Worth);
                ViewBag.TotalW = TotalWorth;
            }
            else ViewBag.TotalW = TotalWorth;
            var Minus = Math.Abs(TotalWorth - TotalCost);
            ViewBag.Difference = Minus;
            if (TotalWorth > 0)
            {
                int percentComplete = (int)Math.Round((double)(100 * Minus) / TotalWorth);
                ViewBag.Percentage = percentComplete;
                ViewBag.OK = 1;
            }
            else ViewBag.OK = 0;
            if (!String.IsNullOrEmpty(searchString))
            {
                expenses = expenses.Where(s => s.FullName.Contains(searchString));
            }
            //if(DateIn != null && DateOut != null)
            //{
            //    expenses = expenses.Where(s => s.PaymentDate >= DateIn
            //                                && s.PaymentDate <= DateOut);
            //}
            if (expenses.Count() != 0)
            {
                var TotalC = expenses.Sum(x => x.Cost);
                ViewBag.TotalS = TotalC;
            }
            else ViewBag.TotalS = 0;
            switch (sortOrder)
            {
                case "cost_desc":
                    expenses = expenses.OrderByDescending(s => s.Cost);
                    break;
                case "Date":
                    expenses = expenses.OrderBy(s => s.PaymentDate);
                    break;
                case "cost_asc":
                    expenses = expenses.OrderBy(s => s.Cost);
                    break;
                default:
                    expenses = expenses.OrderByDescending(s => s.PaymentDate);
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(expenses.ToPagedList(pageNumber, pageSize));
        }

        // GET: Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullName,Cost,PaymentDate")] Expense expense)
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
                    expense.OwnerID = userId;//Membership.GetUser(User.Identity.Name).;
                    db.Expenses.Add(expense);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(expense);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullName,Cost,PaymentDate")] Expense expense)
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
                expense.OwnerID = userId;//Membership.GetUser(User.Identity.Name).;
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        // GET: Expense/Delete/5
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
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
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
