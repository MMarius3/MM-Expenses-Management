using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpensesManagementProject.Models
{
    public class Income
    {
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public string FullName { get; set; }
        public int Worth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WageDate { get; set; }
        public string Secret { get; set; }
        public IncContactStatus Status { get; set; }
        public virtual ICollection<Wage> Wages { get; set; }
    }

    public enum IncContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}