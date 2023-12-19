namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPages", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages");
            DropIndex("dbo.UserPages", new[] { "User_UserID" });
            DropIndex("dbo.UserPages", new[] { "Page_PageID" });
            AddColumn("dbo.Pages", "User_UserID", c => c.Int());
            AddColumn("dbo.Pages", "User_UserID1", c => c.Int());
            AddColumn("dbo.Users", "Page_PageID", c => c.Int());
            CreateIndex("dbo.Pages", "User_UserID");
            CreateIndex("dbo.Pages", "User_UserID1");
            CreateIndex("dbo.Users", "Page_PageID");
            AddForeignKey("dbo.Pages", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Pages", "User_UserID1", "dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "Page_PageID", "dbo.Pages", "PageID");
            DropTable("dbo.UserPages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserPages",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Page_PageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Page_PageID });
            
            DropForeignKey("dbo.Users", "Page_PageID", "dbo.Pages");
            DropForeignKey("dbo.Pages", "User_UserID1", "dbo.Users");
            DropForeignKey("dbo.Pages", "User_UserID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Page_PageID" });
            DropIndex("dbo.Pages", new[] { "User_UserID1" });
            DropIndex("dbo.Pages", new[] { "User_UserID" });
            DropColumn("dbo.Users", "Page_PageID");
            DropColumn("dbo.Pages", "User_UserID1");
            DropColumn("dbo.Pages", "User_UserID");
            CreateIndex("dbo.UserPages", "Page_PageID");
            CreateIndex("dbo.UserPages", "User_UserID");
            AddForeignKey("dbo.UserPages", "Page_PageID", "dbo.Pages", "PageID", cascadeDelete: true);
            AddForeignKey("dbo.UserPages", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
