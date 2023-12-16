namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookLoans", "GroupID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookLoans", "GroupID", c => c.Int(nullable: false));
        }
    }
}
