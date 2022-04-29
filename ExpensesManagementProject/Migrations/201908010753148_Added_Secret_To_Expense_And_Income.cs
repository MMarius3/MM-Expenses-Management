namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Secret_To_Expense_And_Income : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Income",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Worth = c.String(),
                        WageDate = c.DateTime(nullable: false),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Wage",
                c => new
                    {
                        WageID = c.Int(nullable: false, identity: true),
                        IncomeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WageID)
                .ForeignKey("dbo.Income", t => t.IncomeID, cascadeDelete: true)
                .Index(t => t.IncomeID);
            
            AddColumn("dbo.Expense", "Secret", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wage", "IncomeID", "dbo.Income");
            DropIndex("dbo.Wage", new[] { "IncomeID" });
            DropColumn("dbo.Expense", "Secret");
            DropTable("dbo.Wage");
            DropTable("dbo.Income");
        }
    }
}
