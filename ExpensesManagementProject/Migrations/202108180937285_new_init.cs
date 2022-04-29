namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExpenseAndIncome", "ExpenseID", "dbo.Expense");
            DropForeignKey("dbo.ExpenseAndIncome", "IncomeID", "dbo.Income");
            DropIndex("dbo.ExpenseAndIncome", new[] { "ExpenseID" });
            DropIndex("dbo.ExpenseAndIncome", new[] { "IncomeID" });
            DropColumn("dbo.Expense", "ConvertFromExpense");
            DropColumn("dbo.Income", "ConvertFromIncome");
            DropTable("dbo.ExpenseAndIncome");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExpenseAndIncome",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConvertID = c.Int(nullable: false),
                        OwnerID = c.String(),
                        FullName = c.String(),
                        CostOrWorth = c.Int(nullable: false),
                        PaymentOrWageDate = c.DateTime(nullable: false),
                        Secret = c.String(),
                        ExpOrInc = c.String(),
                        ExpenseID = c.Int(),
                        IncomeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Income", "ConvertFromIncome", c => c.Int(nullable: false));
            AddColumn("dbo.Expense", "ConvertFromExpense", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpenseAndIncome", "IncomeID");
            CreateIndex("dbo.ExpenseAndIncome", "ExpenseID");
            AddForeignKey("dbo.ExpenseAndIncome", "IncomeID", "dbo.Income", "ID");
            AddForeignKey("dbo.ExpenseAndIncome", "ExpenseID", "dbo.Expense", "ID");
        }
    }
}
