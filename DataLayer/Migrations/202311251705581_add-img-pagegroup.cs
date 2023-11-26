namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimgpagegroup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "ImageName", c => c.Int(nullable: false));
        }
    }
}
