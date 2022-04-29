using System;
using System.Collections.Generic;
using ExpensesManagementProject.Models;

namespace ExpensesManagementProject.DAL
{
    public class ProjectInitializer : System.Data.Entity.CreateDatabaseIfNotExists<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            //var expenses = new List<Expense>
            //{
            //    new Expense{FullName="Car",Cost="20000",PaymentDate=DateTime.Parse("2015-09-01")},
            //    new Expense{FullName="Eating out",Cost="50",PaymentDate=DateTime.Parse("2012-09-01")},
            //    new Expense{FullName="Food",Cost="100",PaymentDate=DateTime.Parse("2013-09-01")},
            //    new Expense{FullName="Health",Cost="250",PaymentDate=DateTime.Parse("2012-09-01")},
            //    new Expense{FullName="Sports",Cost="200",PaymentDate=DateTime.Parse("2012-09-01")},
            //    new Expense{FullName="Transport",Cost="30",PaymentDate=DateTime.Parse("2011-09-01")},
            //    new Expense{FullName="Toiletry",Cost="100",PaymentDate=DateTime.Parse("2013-09-01")},
            //    new Expense{FullName="House",Cost="700000",PaymentDate=DateTime.Parse("2015-09-01")}
            //};

            ////expenses.ForEach(s => context.Expenses.Add(s));
            //context.Expenses.AddRange(expenses);
            //context.SaveChanges();
            ////var courses = new List<Course>
            ////{
            ////new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            ////new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            ////new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            ////new Course{CourseID=1045,Title="Calculus",Credits=4,},
            ////new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            ////new Course{CourseID=2021,Title="Composition",Credits=3,},
            ////new Course{CourseID=2042,Title="Literature",Credits=4,}
            ////};
            ////courses.ForEach(s => context.Courses.Add(s));
            ////context.SaveChanges();
            //var payments = new List<Payment>
            //{
            //new Payment{ExpenseID=1},
            //new Payment{ExpenseID=2},
            //new Payment{ExpenseID=3},
            //new Payment{ExpenseID=4},
            //new Payment{ExpenseID=5},
            //new Payment{ExpenseID=6},
            //new Payment{ExpenseID=7}
            //};
            //payments.ForEach(s => context.Payments.Add(s));
            //context.SaveChanges();
        }
    }
}