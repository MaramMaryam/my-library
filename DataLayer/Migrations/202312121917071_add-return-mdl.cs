namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreturnmdl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans");
            DropIndex("dbo.Users", new[] { "Loan_LoanID" });
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
            
            AddColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 350));
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "LoanCount");
            DropColumn("dbo.Users", "Loan_LoanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Loan_LoanID", c => c.Int());
            AddColumn("dbo.Users", "LoanCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 250));
            DropForeignKey("dbo.UserLoans", "Loan_LoanID", "dbo.Loans");
            DropForeignKey("dbo.UserLoans", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserLoans", new[] { "Loan_LoanID" });
            DropIndex("dbo.UserLoans", new[] { "User_UserID" });
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "FullName");
            DropTable("dbo.UserLoans");
            CreateIndex("dbo.Users", "Loan_LoanID");
            AddForeignKey("dbo.Users", "Loan_LoanID", "dbo.Loans", "LoanID");
        }
    }
}
