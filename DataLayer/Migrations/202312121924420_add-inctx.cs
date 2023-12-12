namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinctx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Returns",
                c => new
                    {
                        ReturnID = c.Int(nullable: false, identity: true),
                        LoanID = c.Int(nullable: false),
                        PageID = c.Int(nullable: false),
                        PageGroupID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ReturnedDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        PenalityFee = c.Double(nullable: false),
                        PageGroup_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.ReturnID)
                .ForeignKey("dbo.PageGroups", t => t.PageGroup_GroupID)
                .Index(t => t.PageGroup_GroupID);
            
            AddColumn("dbo.Pages", "Return_ReturnID", c => c.Int());
            AddColumn("dbo.Users", "Return_ReturnID", c => c.Int());
            CreateIndex("dbo.Pages", "Return_ReturnID");
            CreateIndex("dbo.Users", "Return_ReturnID");
            AddForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns", "ReturnID");
            AddForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns", "ReturnID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Return_ReturnID", "dbo.Returns");
            DropForeignKey("dbo.Returns", "PageGroup_GroupID", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "Return_ReturnID", "dbo.Returns");
            DropIndex("dbo.Returns", new[] { "PageGroup_GroupID" });
            DropIndex("dbo.Users", new[] { "Return_ReturnID" });
            DropIndex("dbo.Pages", new[] { "Return_ReturnID" });
            DropColumn("dbo.Users", "Return_ReturnID");
            DropColumn("dbo.Pages", "Return_ReturnID");
            DropTable("dbo.Returns");
        }
    }
}
