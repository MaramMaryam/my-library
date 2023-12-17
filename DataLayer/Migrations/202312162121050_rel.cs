namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans");
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
            
            DropColumn("dbo.Pages", "bookLoan_BookLoanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "bookLoan_BookLoanID", c => c.Int());
            DropForeignKey("dbo.PageBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.PageBookLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.PageBookLoans", new[] { "BookLoan_BookLoanID" });
            DropIndex("dbo.PageBookLoans", new[] { "Page_PageID" });
            DropTable("dbo.PageBookLoans");
            CreateIndex("dbo.Pages", "bookLoan_BookLoanID");
            AddForeignKey("dbo.Pages", "bookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID");
        }
    }
}
