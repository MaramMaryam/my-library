namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookLoans", "LoanUntill", c => c.DateTime());
            DropColumn("dbo.BookLoans", "GroupID");
            DropColumn("dbo.BookLoans", "ReturnedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookLoans", "ReturnedDate", c => c.DateTime());
            AddColumn("dbo.BookLoans", "GroupID", c => c.Int());
            AlterColumn("dbo.BookLoans", "LoanUntill", c => c.DateTime(nullable: false));
        }
    }
}
