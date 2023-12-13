namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addneitial : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.PageGroups", t => t.PageGroup_GroupID)
                .Index(t => t.PageGroup_GroupID);
            
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
            
            AddColumn("dbo.Pages", "AuthorID", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "BorrowPersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "IsBorrow", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pages", "BorrowedDate", c => c.String());
            AddColumn("dbo.Pages", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "revivalCount", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "Return_ReturnID", c => c.Int());
            AddColumn("dbo.Users", "Return_ReturnID", c => c.Int());
            CreateIndex("dbo.Pages", "Return_ReturnID");
            CreateIndex("dbo.Users", "Return_ReturnID");
            AddForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns", "ReturnID");
            AddForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns", "ReturnID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Loans", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PageLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.PageLoans", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.UserLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserLoans", new[] { "User_UserID" });
            DropIndex("dbo.PageLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.PageLoans", new[] { "Page_PageID" });
            DropIndex("dbo.Returns", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.Users", new[] { "Return_ReturnID" });
            DropIndex("dbo.Pages", new[] { "Return_ReturnID" });
            DropIndex("dbo.Loans", new[] { "PageGroup_GroupID" });
            DropColumn("dbo.Users", "Return_ReturnID");
            DropColumn("dbo.Pages", "Return_ReturnID");
            DropColumn("dbo.Pages", "revivalCount");
            DropColumn("dbo.Pages", "LoanCount");
            DropColumn("dbo.Pages", "BorrowedDate");
            DropColumn("dbo.Pages", "IsBorrow");
            DropColumn("dbo.Pages", "BorrowPersonID");
            DropColumn("dbo.Pages", "AuthorID");
            DropTable("dbo.UserLoans");
            DropTable("dbo.PageLoans");
            DropTable("dbo.Returns");
            DropTable("dbo.Loans");
        }
    }
}
