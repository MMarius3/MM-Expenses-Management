namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCluj : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Expense", newName: "Expenses");
            RenameTable(name: "dbo.Payment", newName: "Payments");
            RenameTable(name: "dbo.Income", newName: "Incomes");
            RenameTable(name: "dbo.Wage", newName: "Wages");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Wages", newName: "Wage");
            RenameTable(name: "dbo.Incomes", newName: "Income");
            RenameTable(name: "dbo.Payments", newName: "Payment");
            RenameTable(name: "dbo.Expenses", newName: "Expense");
        }
    }
}
