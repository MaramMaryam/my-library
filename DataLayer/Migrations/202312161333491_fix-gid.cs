namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixgid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookLoans", "GroupID", c => c.Int(nullable: false));
            DropColumn("dbo.BookLoans", "PageGroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookLoans", "PageGroupID", c => c.Int(nullable: false));
            DropColumn("dbo.BookLoans", "GroupID");
        }
    }
}
