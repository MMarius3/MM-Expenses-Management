namespace ExpensesManagementProject.Migrations
{
    using ExpensesManagementProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpensesManagementProject.DAL.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ExpensesManagementProject.DAL.ProjectContext";
        }

        protected override void Seed(ExpensesManagementProject.DAL.ProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

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
        }
    }
}
