namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addloancount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "LoanCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LoanCount");
            DropColumn("dbo.Pages", "LoanCount");
        }
    }
}
