namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageGroups", "bookLoan_BookLoanID", c => c.Int());
            CreateIndex("dbo.PageGroups", "bookLoan_BookLoanID");
            AddForeignKey("dbo.PageGroups", "bookLoan_BookLoanID", "dbo.BookLoans", "BookLoanID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageGroups", "bookLoan_BookLoanID", "dbo.BookLoans");
            DropIndex("dbo.PageGroups", new[] { "bookLoan_BookLoanID" });
            DropColumn("dbo.PageGroups", "bookLoan_BookLoanID");
        }
    }
}
