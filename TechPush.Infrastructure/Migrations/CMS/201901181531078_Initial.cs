namespace TechPush.Infrastructure.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "Blog.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UrlSlug = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "Blog.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        ShortDescription = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Meta = c.String(nullable: false, maxLength: 1000),
                        UrlSlug = c.String(nullable: false, maxLength: 1000),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        CategoryId = c.Int(nullable: false),
                        Shed = c.Boolean(nullable: false),
                        RegionId = c.Int(nullable: false),
                        Publisher = c.String(nullable: false, maxLength: 50),
                        MobileNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("Blog.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("Blog.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.RegionId);
            
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
                "Blog.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UrlSlug = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("Blog.Posts", t => t.Post_PostId)
                .Index(t => t.Post_PostId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blog.HotNews", "Advertiser_Id", "Blog.Advertisers");
            DropForeignKey("Blog.Tags", "Post_PostId", "Blog.Posts");
            DropForeignKey("Blog.Posts", "RegionId", "Blog.Regions");
            DropForeignKey("Blog.Posts", "CategoryId", "Blog.Categories");
            DropIndex("Blog.HotNews", new[] { "Advertiser_Id" });
            DropIndex("Blog.Tags", new[] { "Post_PostId" });
            DropIndex("Blog.Posts", new[] { "RegionId" });
            DropIndex("Blog.Posts", new[] { "CategoryId" });
            DropTable("Blog.HotNews");
            DropTable("Blog.Tags");
            DropTable("Blog.Regions");
            DropTable("Blog.Posts");
            DropTable("Blog.Categories");
            DropTable("Blog.Advertisers");
        }
    }
}
