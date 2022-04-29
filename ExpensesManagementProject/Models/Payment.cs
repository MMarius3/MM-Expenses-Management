using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesManagementProject.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int ExpenseID { get; set; }

        public virtual Expense Expense { get; set; }
    }
}