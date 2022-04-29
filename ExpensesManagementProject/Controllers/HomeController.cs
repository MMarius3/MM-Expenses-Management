using ExpensesManagementProject.DAL;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ExpensesManagementProject.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            
            var incomes = from s in db.Incomes
                          select s;
            var expenses = from s in db.Expenses
                           select s;
            var TotalWorth = incomes.Sum(x => x.Worth);
            var TotalCost = expenses.Sum(y => y.Cost);
            var Minus = Math.Abs(TotalWorth - TotalCost);
            ViewBag.Difference = Minus;
            int percentComplete = (int)Math.Round((double)(100 * Minus) / TotalWorth);
            ViewBag.Percentage = percentComplete;
            ViewBag.TotalW = TotalWorth;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}