namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adedrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserBookLoans", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans");
            DropIndex("dbo.UserBookLoans", new[] { "User_UserID" });
            DropIndex("dbo.UserBookLoans", new[] { "BookLoan_BookLoanID" });
            CreateIndex("dbo.BookLoans", "UserID");
            AddForeignKey("dbo.BookLoans", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            DropTable("dbo.UserBookLoans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserBookLoans",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        BookLoan_BookLoanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.BookLoan_BookLoanID });
            
            DropForeignKey("dbo.BookLoans", "UserID", "dbo.Users");
            DropIndex("dbo.BookLoans", new[] { "UserID" });
            CreateIndex("dbo.UserBookLoans", "BookLoan_BookLoanID");
            CreateIndex("dbo.UserBookLoans", "User_UserID");
            AddForeignKey("dbo.UserBookLoans", "BookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID", cascadeDelete: true);
            AddForeignKey("dbo.UserBookLoans", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
