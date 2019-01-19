namespace TechPush.Infrastructure.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blog.Advertisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertiserName = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 800),
                        MobileNo = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Blog.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(nullable: false, maxLength: 500),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "Blog.HotNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotNewsText = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 800),
                        PostedOn = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                        Advertiser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.Advertisers", t => t.Advertiser_Id, cascadeDelete: true)
                .Index(t => t.Advertiser_Id);
            
            AddColumn("Blog.Categories", "Enable", c => c.Boolean(nullable: false));
            AddColumn("Blog.Posts", "Publisher", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Blog.Posts", "MobileNo", c => c.String(nullable: false));
            AddColumn("Blog.Posts", "Region_RegionId", c => c.Int(nullable: false));
            CreateIndex("Blog.Posts", "Region_RegionId");
            AddForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions", "RegionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Blog.HotNews", "Advertiser_Id", "Blog.Advertisers");
            DropForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions");
            DropIndex("Blog.HotNews", new[] { "Advertiser_Id" });
            DropIndex("Blog.Posts", new[] { "Region_RegionId" });
            DropColumn("Blog.Posts", "Region_RegionId");
            DropColumn("Blog.Posts", "MobileNo");
            DropColumn("Blog.Posts", "Publisher");
            DropColumn("Blog.Categories", "Enable");
            DropTable("Blog.HotNews");
            DropTable("Blog.Regions");
            DropTable("Blog.Advertisers");
        }
    }
}
