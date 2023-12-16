namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addloanbooks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.Loans", "PageGroup_GroupID", "dbo.PageGroups");
            DropIndex("dbo.Loans", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.PageLoans", new[] { "Page_PageID" });
            DropIndex("dbo.PageLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserLoans", new[] { "User_UserID" });
            DropIndex("dbo.UserLoans", new[] { "Loan_LoanID" });
            CreateTable(
                "dbo.BookLoans",
                c => new
                    {
                        BookLoanID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        PageGroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ReturnedDate = c.DateTime(),
                        LoanFrom = c.DateTime(nullable: false),
                        LoanUntill = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookLoanID);
            
            CreateTable(
                "dbo.UserBookLoans",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        BookLoan_BookLoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.BookLoan_BookLoanID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.BookLoans", t => t.BookLoan_BookLoanID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.BookLoan_BookLoanID);
            
            AddColumn("dbo.Pages", "BookLoan_BookLoanID", c => c.Int());
            CreateIndex("dbo.Pages", "BookLoan_BookLoanID");
            AddForeignKey("dbo.Pages", "BookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID");
            DropTable("dbo.Loans");
            DropTable("dbo.PageLoans");
            DropTable("dbo.UserLoans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserLoans",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Loan_LoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Loan_LoanID });
            
            CreateTable(
                "dbo.PageLoans",
                c => new
                    {
                        Page_PageID = c.Int(nullable: false),
                        Loan_LoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Page_PageID, t.Loan_LoanID });
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        PageGroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LoanFrom = c.DateTime(nullable: false),
                        LoanUntill = c.DateTime(nullable: false),
                        PageGroup_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.LoanID);
            
            DropForeignKey("dbo.Pages", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.UserBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.UserBookLoans", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserBookLoans", new[] { "BookLoan_BookLoanID" });
            DropIndex("dbo.UserBookLoans", new[] { "User_UserID" });
            DropIndex("dbo.Pages", new[] { "BookLoan_BookLoanID" });
            DropColumn("dbo.Pages", "BookLoan_BookLoanID");
            DropTable("dbo.UserBookLoans");
            DropTable("dbo.BookLoans");
            CreateIndex("dbo.UserLoans", "Loan_LoanID");
            CreateIndex("dbo.UserLoans", "User_UserID");
            CreateIndex("dbo.PageLoans", "Loan_LoanID");
            CreateIndex("dbo.PageLoans", "Page_PageID");
            CreateIndex("dbo.Loans", "PageGroup_GroupID");
            AddForeignKey("dbo.Loans", "PageGroup_GroupID", "dbo.PageGroups", "GroupID");
            AddForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans", "LoanID", cascadeDelete: true);
            AddForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans", "LoanID", cascadeDelete: true);
            AddForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages", "PageID", cascadeDelete: true);
        }
    }
}
