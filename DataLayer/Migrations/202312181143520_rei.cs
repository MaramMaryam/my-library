namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rei : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginID);
            
            CreateTable(
                "dbo.BookLoans",
                c => new
                    {
                        BookLoanID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LoanFrom = c.DateTime(nullable: false),
                        LoanUntill = c.DateTime(),
                    })
                .PrimaryKey(t => t.BookLoanID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        Author = c.String(nullable: false, maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tags = c.String(),
                        BookLoan_BookLoanID = c.Int(),
                        Return_ReturnID = c.Int(),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageGroups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.BookLoans", t => t.BookLoan_BookLoanID)
                .ForeignKey("dbo.Returns", t => t.Return_ReturnID)
                .Index(t => t.GroupID)
                .Index(t => t.BookLoan_BookLoanID)
                .Index(t => t.Return_ReturnID);
            
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        PageID = c.Int(nullable: false),
                        Name = c.String(maxLength: 150),
                        Email = c.String(maxLength: 200),
                        Website = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Pages", t => t.PageID, cascadeDelete: true)
                .Index(t => t.PageID);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                        GroupImgName = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 250),
                        Code = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tel = c.String(nullable: false, maxLength: 350),
                        Email = c.String(maxLength: 350),
                        Return_ReturnID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Returns", t => t.Return_ReturnID)
                .Index(t => t.Return_ReturnID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Pages", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.UserPages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropForeignKey("dbo.UserBookLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Pages", "GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "PageID", "dbo.Pages");
            DropIndex("dbo.UserPages", new[] { "Page_PageID" });
            DropIndex("dbo.UserPages", new[] { "User_UserID" });
            DropIndex("dbo.UserBookLoans", new[] { "BookLoan_BookLoanID" });
            DropIndex("dbo.UserBookLoans", new[] { "User_UserID" });
            DropIndex("dbo.Returns", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.Users", new[] { "Return_ReturnID" });
            DropIndex("dbo.PageComments", new[] { "PageID" });
            DropIndex("dbo.Pages", new[] { "Return_ReturnID" });
            DropIndex("dbo.Pages", new[] { "BookLoan_BookLoanID" });
            DropIndex("dbo.Pages", new[] { "GroupID" });
            DropTable("dbo.UserPages");
            DropTable("dbo.UserBookLoans");
            DropTable("dbo.Returns");
            DropTable("dbo.Users");
            DropTable("dbo.PageGroups");
            DropTable("dbo.PageComments");
            DropTable("dbo.Pages");
            DropTable("dbo.BookLoans");
            DropTable("dbo.AdminLogins");
        }
    }
}
