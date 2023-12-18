namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class single : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageBookLoans", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.PageBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropIndex("dbo.PageBookLoans", new[] { "Page_PageID" });
            DropIndex("dbo.PageBookLoans", new[] { "BookLoan_BookLoanID" });
            CreateIndex("dbo.BookLoans", "PageID");
            AddForeignKey("dbo.BookLoans", "PageID", "dbo.Pages", "PageID", cascadeDelete: true);
            DropTable("dbo.PageBookLoans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PageBookLoans",
                c => new
                    {
                        Page_PageID = c.Int(nullable: false),
                        BookLoan_BookLoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Page_PageID, t.BookLoan_BookLoanID });
            
            DropForeignKey("dbo.BookLoans", "PageID", "dbo.Pages");
            DropIndex("dbo.BookLoans", new[] { "PageID" });
            CreateIndex("dbo.PageBookLoans", "BookLoan_BookLoanID");
            CreateIndex("dbo.PageBookLoans", "Page_PageID");
            AddForeignKey("dbo.PageBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID", cascadeDelete: true);
            AddForeignKey("dbo.PageBookLoans", "Page_PageID", "dbo.Pages", "PageID", cascadeDelete: true);
        }
    }
}
