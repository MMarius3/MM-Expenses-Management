namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Cost = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        ExpenseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Expense", t => t.ExpenseID, cascadeDelete: true)
                .Index(t => t.ExpenseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "ExpenseID", "dbo.Expense");
            DropIndex("dbo.Payment", new[] { "ExpenseID" });
            DropTable("dbo.Payment");
            DropTable("dbo.Expense");
        }
    }
}
