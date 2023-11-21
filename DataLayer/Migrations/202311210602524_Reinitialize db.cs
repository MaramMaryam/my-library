namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinitializedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "LongDescription", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.PageGroups", "ImageGrpName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageGroups", "ImageGrpName");
            DropColumn("dbo.Pages", "LongDescription");
        }
    }
}
