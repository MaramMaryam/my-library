namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chngetypeofdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageComments", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageComments", "CreateDate", c => c.String());
        }
    }
}
