namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addviewmolelbook : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pages", "AuthorID");
            DropColumn("dbo.Pages", "AvailableCount");
            DropColumn("dbo.Pages", "BorrowPersonID");
            DropColumn("dbo.Pages", "IsBorrow");
            DropColumn("dbo.Pages", "BorrowedDate");
            DropColumn("dbo.Pages", "LoanCount");
            DropColumn("dbo.Pages", "revivalCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "revivalCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "BorrowedDate", c => c.String());
            AddColumn("dbo.Pages", "IsBorrow", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "BorrowPersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "AvailableCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "AuthorID", c => c.Int(nullable: false));
        }
    }
}
