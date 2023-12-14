namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "PageGroup_GroupID", "dbo.PageGroups");
            DropIndex("dbo.Users", new[] { "PageGroup_GroupID" });
            DropColumn("dbo.Users", "PageGroup_GroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PageGroup_GroupID", c => c.Int());
            CreateIndex("dbo.Users", "PageGroup_GroupID");
            AddForeignKey("dbo.Users", "PageGroup_GroupID", "dbo.PageGroups", "GroupID");
        }
    }
}
