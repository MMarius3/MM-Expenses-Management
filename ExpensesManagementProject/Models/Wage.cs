using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesManagementProject.Models
{
    public class Wage
    {
        public int WageID { get; set; }
        public int IncomeID { get; set; }
        public virtual Income Income { get; set; }
    }
}