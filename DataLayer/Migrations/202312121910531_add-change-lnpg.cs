namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchangelnpg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.Pages", "User_UserID", "dbo.Users");
            DropIndex("dbo.Pages", new[] { "Loan_LoanID" });
            DropIndex("dbo.Pages", new[] { "User_UserID" });
            CreateTable(
                "dbo.PageLoans",
                c => new
                    {
                        Page_PageID = c.Int(nullable: false),
                        Loan_LoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Page_PageID, t.Loan_LoanID })
                .ForeignKey("dbo.Pages", t => t.Page_PageID, cascadeDelete: true)
                .ForeignKey("dbo.Loans", t => t.Loan_LoanID, cascadeDelete: true)
                .Index(t => t.Page_PageID)
                .Index(t => t.Loan_LoanID);
            
            CreateTable(
                "dbo.UserPages",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Page_PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Page_PageID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_PageID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Page_PageID);
            
            AddColumn("dbo.Pages", "AvailableCount", c => c.Int(nullable: false));
            DropColumn("dbo.Pages", "Loan_LoanID");
            DropColumn("dbo.Pages", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "User_UserID", c => c.Int());
            AddColumn("dbo.Pages", "Loan_LoanID", c => c.Int());
            DropForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.UserPages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.UserPages", new[] { "Page_PageID" });
            DropIndex("dbo.UserPages", new[] { "User_UserID" });
            DropIndex("dbo.PageLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.PageLoans", new[] { "Page_PageID" });
            DropColumn("dbo.Pages", "AvailableCount");
            DropTable("dbo.UserPages");
            DropTable("dbo.PageLoans");
            CreateIndex("dbo.Pages", "User_UserID");
            CreateIndex("dbo.Pages", "Loan_LoanID");
            AddForeignKey("dbo.Pages", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans", "LoanID");
        }
    }
}
