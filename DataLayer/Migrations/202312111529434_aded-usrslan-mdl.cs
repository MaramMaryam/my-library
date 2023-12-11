namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adedusrslanmdl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "LoanFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "LoanUntill", c => c.DateTime(nullable: false));
            DropColumn("dbo.Loans", "LoanDate");
            DropColumn("dbo.Loans", "RetunDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "RetunDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "LoanDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Loans", "LoanUntill");
            DropColumn("dbo.Loans", "LoanFrom");
        }
    }
}
