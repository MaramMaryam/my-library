namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserloan : DbMigration
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
                        LoanDate = c.DateTime(nullable: false),
                        RetunDate = c.DateTime(nullable: false),
                        PageGroup_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.PageGroups", t => t.PageGroup_GroupID)
                .Index(t => t.PageGroup_GroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Code = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tel = c.String(nullable: false, maxLength: 350),
                        PageGroup_GroupID = c.Int(),
                        Loan_LoanID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.PageGroups", t => t.PageGroup_GroupID)
                .ForeignKey("dbo.Loans", t => t.Loan_LoanID)
                .Index(t => t.PageGroup_GroupID)
                .Index(t => t.Loan_LoanID);
            
            AddColumn("dbo.Pages", "Loan_LoanID", c => c.Int());
            AddColumn("dbo.Pages", "User_UserID", c => c.Int());
            CreateIndex("dbo.Pages", "Loan_LoanID");
            CreateIndex("dbo.Pages", "User_UserID");
            AddForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans", "LoanID");
            AddForeignKey("dbo.Pages", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.Users", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Loans", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "Loan_LoanID", "dbo.Loans");
            DropIndex("dbo.Users", new[] { "Loan_LoanID" });
            DropIndex("dbo.Users", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.Pages", new[] { "User_UserID" });
            DropIndex("dbo.Pages", new[] { "Loan_LoanID" });
            DropIndex("dbo.Loans", new[] { "PageGroup_GroupID" });
            DropColumn("dbo.Pages", "User_UserID");
            DropColumn("dbo.Pages", "Loan_LoanID");
            DropTable("dbo.Users");
            DropTable("dbo.Loans");
        }
    }
}
