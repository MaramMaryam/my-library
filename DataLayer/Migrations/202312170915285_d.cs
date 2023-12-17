namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookLoans", "PageID", "dbo.Pages");
            DropIndex("dbo.BookLoans", new[] { "PageID" });
            AddColumn("dbo.BookLoans", "Page_PageID", c => c.Int());
            AddColumn("dbo.BookLoans", "Pages_PageID", c => c.Int());
            AddColumn("dbo.Pages", "bookLoan_BookLoanID", c => c.Int());
            CreateIndex("dbo.BookLoans", "Page_PageID");
            CreateIndex("dbo.BookLoans", "Pages_PageID");
            CreateIndex("dbo.Pages", "bookLoan_BookLoanID");
            AddForeignKey("dbo.BookLoans", "Page_PageID", "dbo.Pages", "PageID");
            AddForeignKey("dbo.BookLoans", "Pages_PageID", "dbo.Pages", "PageID");
            AddForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.BookLoans", "Pages_PageID", "dbo.Pages");
            DropForeignKey("dbo.BookLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "bookLoan_BookLoanID" });
            DropIndex("dbo.BookLoans", new[] { "Pages_PageID" });
            DropIndex("dbo.BookLoans", new[] { "Page_PageID" });
            DropColumn("dbo.Pages", "bookLoan_BookLoanID");
            DropColumn("dbo.BookLoans", "Pages_PageID");
            DropColumn("dbo.BookLoans", "Page_PageID");
            CreateIndex("dbo.BookLoans", "PageID");
            AddForeignKey("dbo.BookLoans", "PageID", "dbo.Pages", "PageID", cascadeDelete: true);
        }
    }
}
