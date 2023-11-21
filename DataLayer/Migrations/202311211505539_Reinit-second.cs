namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinitsecond : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageGroups", "ImageName", c => c.String());
            DropColumn("dbo.PageGroups", "ImageGrpName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PageGroups", "ImageGrpName", c => c.String());
            DropColumn("dbo.PageGroups", "ImageName");
        }
    }
}
