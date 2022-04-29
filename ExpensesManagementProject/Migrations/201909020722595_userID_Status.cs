namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userID_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expense", "OwnerID", c => c.String());
            AddColumn("dbo.Expense", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Income", "OwnerID", c => c.String());
            AddColumn("dbo.Income", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Income", "Status");
            DropColumn("dbo.Income", "OwnerID");
            DropColumn("dbo.Expense", "Status");
            DropColumn("dbo.Expense", "OwnerID");
        }
    }
}
