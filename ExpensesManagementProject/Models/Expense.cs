using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ExpensesManagementProject.Models
{
    public class Expense
    {
        public int ID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }
        public string FullName { get; set; }
        public int Cost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }
        public string Secret { get; set; }
        public ExpContactStatus Status { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        //public int TotalSum { get; set; }
    }
        public enum ExpContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}