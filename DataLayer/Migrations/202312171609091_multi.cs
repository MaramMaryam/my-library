namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.BookLoans", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.BookLoans", "Pages_PageID", "dbo.Pages");
            DropIndex("dbo.BookLoans", new[] { "Page_PageID" });
            DropIndex("dbo.BookLoans", new[] { "Pages_PageID" });
            DropIndex("dbo.Pages", new[] { "bookLoan_BookLoanID" });
            CreateTable(
                "dbo.PageBookLoans",
                c => new
                    {
                        Page_PageID = c.Int(nullable: false),
                        BookLoan_BookLoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Page_PageID, t.BookLoan_BookLoanID })
                .ForeignKey("dbo.Pages", t => t.Page_PageID, cascadeDelete: true)
                .ForeignKey("dbo.BookLoans", t => t.BookLoan_BookLoanID, cascadeDelete: true)
                .Index(t => t.Page_PageID)
                .Index(t => t.BookLoan_BookLoanID);
            
            DropColumn("dbo.BookLoans", "Page_PageID");
            DropColumn("dbo.BookLoans", "Pages_PageID");
            DropColumn("dbo.Pages", "bookLoan_BookLoanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "bookLoan_BookLoanID", c => c.Int());
            AddColumn("dbo.BookLoans", "Pages_PageID", c => c.Int());
            AddColumn("dbo.BookLoans", "Page_PageID", c => c.Int());
            DropForeignKey("dbo.PageBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.PageBookLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.PageBookLoans", new[] { "BookLoan_BookLoanID" });
            DropIndex("dbo.PageBookLoans", new[] { "Page_PageID" });
            DropTable("dbo.PageBookLoans");
            CreateIndex("dbo.Pages", "bookLoan_BookLoanID");
            CreateIndex("dbo.BookLoans", "Pages_PageID");
            CreateIndex("dbo.BookLoans", "Page_PageID");
            AddForeignKey("dbo.BookLoans", "Pages_PageID", "dbo.Pages", "PageID");
            AddForeignKey("dbo.BookLoans", "Page_PageID", "dbo.Pages", "PageID");
            AddForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID");
        }
    }
}
