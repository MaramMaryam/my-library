namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewmgint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserPages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns");
            DropIndex("dbo.Pages", new[] { "Return_ReturnID" });
            DropIndex("dbo.Users", new[] { "Return_ReturnID" });
            DropIndex("dbo.Returns", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.PageLoans", new[] { "Page_PageID" });
            DropIndex("dbo.PageLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserLoans", new[] { "User_UserID" });
            DropIndex("dbo.UserLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserPages", new[] { "User_UserID" });
            DropIndex("dbo.UserPages", new[] { "Page_PageID" });
            AddColumn("dbo.Pages", "Loan_LoanID", c => c.Int());
            AddColumn("dbo.Pages", "User_UserID", c => c.Int());
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Users", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Loan_LoanID", c => c.Int());
            CreateIndex("dbo.Pages", "Loan_LoanID");
            CreateIndex("dbo.Pages", "User_UserID");
            CreateIndex("dbo.Users", "Loan_LoanID");
            AddForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans", "LoanID");
            AddForeignKey("dbo.Pages", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans", "LoanID");
            DropColumn("dbo.Pages", "AvailableCount");
            DropColumn("dbo.Pages", "Return_ReturnID");
            DropColumn("dbo.Users", "FullName");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Return_ReturnID");
            DropTable("dbo.Returns");
            DropTable("dbo.PageLoans");
            DropTable("dbo.UserLoans");
            DropTable("dbo.UserPages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserPages",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Page_PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Page_PageID });
            
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
                "dbo.Returns",
                c => new
                    {
                        ReturnID = c.Int(nullable: false, identity: true),
                        LoanID = c.Int(nullable: false),
                        PageID = c.Int(nullable: false),
                        PageGroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ReturnedDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        PenalityFee = c.Double(nullable: false),
                        PageGroup_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.ReturnID);
            
            AddColumn("dbo.Users", "Return_ReturnID", c => c.Int());
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 350));
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pages", "Return_ReturnID", c => c.Int());
            AddColumn("dbo.Pages", "AvailableCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.Pages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans");
            DropIndex("dbo.Users", new[] { "Loan_LoanID" });
            DropIndex("dbo.Pages", new[] { "User_UserID" });
            DropIndex("dbo.Pages", new[] { "Loan_LoanID" });
            DropColumn("dbo.Users", "Loan_LoanID");
            DropColumn("dbo.Users", "LoanCount");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Pages", "User_UserID");
            DropColumn("dbo.Pages", "Loan_LoanID");
            CreateIndex("dbo.UserPages", "Page_PageID");
            CreateIndex("dbo.UserPages", "User_UserID");
            CreateIndex("dbo.UserLoans", "Loan_LoanID");
            CreateIndex("dbo.UserLoans", "User_UserID");
            CreateIndex("dbo.PageLoans", "Loan_LoanID");
            CreateIndex("dbo.PageLoans", "Page_PageID");
            CreateIndex("dbo.Returns", "PageGroup_GroupID");
            CreateIndex("dbo.Users", "Return_ReturnID");
            CreateIndex("dbo.Pages", "Return_ReturnID");
            AddForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns", "ReturnID");
            AddForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups", "GroupID");
            AddForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns", "ReturnID");
            AddForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages", "PageID", cascadeDelete: true);
            AddForeignKey("dbo.UserPages", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans", "LoanID", cascadeDelete: true);
            AddForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans", "LoanID", cascadeDelete: true);
            AddForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages", "PageID", cascadeDelete: true);
        }
    }
}
