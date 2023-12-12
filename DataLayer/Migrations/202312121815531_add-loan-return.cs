namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addloanreturn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.Pages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans");
            DropIndex("dbo.Pages", new[] { "Loan_LoanID" });
            DropIndex("dbo.Pages", new[] { "User_UserID" });
            DropIndex("dbo.Users", new[] { "Loan_LoanID" });
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
                .PrimaryKey(t => t.ReturnID)
                .ForeignKey("dbo.PageGroups", t => t.PageGroup_GroupID)
                .Index(t => t.PageGroup_GroupID);
            
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
                "dbo.UserLoans",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Loan_LoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Loan_LoanID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Loans", t => t.Loan_LoanID, cascadeDelete: true)
                .Index(t => t.User_UserID)
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
            AddColumn("dbo.Pages", "Return_ReturnID", c => c.Int());
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 350));
            AddColumn("dbo.Users", "Return_ReturnID", c => c.Int());
            CreateIndex("dbo.Pages", "Return_ReturnID");
            CreateIndex("dbo.Users", "Return_ReturnID");
            AddForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns", "ReturnID");
            AddForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns", "ReturnID");
            DropColumn("dbo.Pages", "Loan_LoanID");
            DropColumn("dbo.Pages", "User_UserID");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "LoanCount");
            DropColumn("dbo.Users", "Loan_LoanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Loan_LoanID", c => c.Int());
            AddColumn("dbo.Users", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Pages", "User_UserID", c => c.Int());
            AddColumn("dbo.Pages", "Loan_LoanID", c => c.Int());
            DropForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.UserPages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.UserPages", new[] { "Page_PageID" });
            DropIndex("dbo.UserPages", new[] { "User_UserID" });
            DropIndex("dbo.UserLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserLoans", new[] { "User_UserID" });
            DropIndex("dbo.PageLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.PageLoans", new[] { "Page_PageID" });
            DropIndex("dbo.Returns", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.Users", new[] { "Return_ReturnID" });
            DropIndex("dbo.Pages", new[] { "Return_ReturnID" });
            DropColumn("dbo.Users", "Return_ReturnID");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "FullName");
            DropColumn("dbo.Pages", "Return_ReturnID");
            DropColumn("dbo.Pages", "AvailableCount");
            DropTable("dbo.UserPages");
            DropTable("dbo.UserLoans");
            DropTable("dbo.PageLoans");
            DropTable("dbo.Returns");
            CreateIndex("dbo.Users", "Loan_LoanID");
            CreateIndex("dbo.Pages", "User_UserID");
            CreateIndex("dbo.Pages", "Loan_LoanID");
            AddForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans", "LoanID");
            AddForeignKey("dbo.Pages", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans", "LoanID");
        }
    }
}
