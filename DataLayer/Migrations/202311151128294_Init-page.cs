namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initpage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "ImageName", c => c.String());
            AlterColumn("dbo.Pages", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "CreateDate", c => c.String());
            AlterColumn("dbo.Pages", "ImageName", c => c.Int(nullable: false));
        }
    }
}
