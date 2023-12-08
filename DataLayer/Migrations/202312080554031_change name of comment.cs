namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenameofcomment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageComments", "Name", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageComments", "Name", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
