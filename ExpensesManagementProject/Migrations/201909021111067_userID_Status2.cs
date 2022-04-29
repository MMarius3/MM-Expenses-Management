namespace ExpensesManagementProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userID_Status2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Income", "OwnerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Income", "OwnerID");
        }
    }
}
