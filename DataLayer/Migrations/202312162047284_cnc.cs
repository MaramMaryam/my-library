namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cnc : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pages", new[] { "BookLoan_BookLoanID" });
            AddColumn("dbo.Pages", "BorrowCount", c => c.Int());
            CreateIndex("dbo.Pages", "bookLoan_BookLoanID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pages", new[] { "bookLoan_BookLoanID" });
            DropColumn("dbo.Pages", "BorrowCount");
            CreateIndex("dbo.Pages", "BookLoan_BookLoanID");
        }
    }
}
