namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreturn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookLoans", "ReturnedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookLoans", "ReturnedOn");
        }
    }
}
