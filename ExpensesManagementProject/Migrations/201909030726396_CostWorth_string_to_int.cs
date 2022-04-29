namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CostWorth_string_to_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expense", "Cost", c => c.Int(nullable: false));
            AlterColumn("dbo.Income", "Worth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Income", "Worth", c => c.String());
            AlterColumn("dbo.Expense", "Cost", c => c.String());
        }
    }
}
