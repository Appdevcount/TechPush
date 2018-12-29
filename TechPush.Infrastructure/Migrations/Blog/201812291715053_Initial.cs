namespace TechPush.Infrastructure.Migrations.Blog
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blog.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UrlSlug = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Blog.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        ShortDescription = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Meta = c.String(nullable: false, maxLength: 1000),
                        UrlSlug = c.String(nullable: false, maxLength: 1000),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "Blog.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UrlSlug = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Blog.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("Blog.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("Blog.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blog.TagPosts", "Post_Id", "Blog.Posts");
            DropForeignKey("Blog.TagPosts", "Tag_Id", "Blog.Tags");
            DropForeignKey("Blog.Posts", "Category_Id", "Blog.Categories");
            DropIndex("Blog.TagPosts", new[] { "Post_Id" });
            DropIndex("Blog.TagPosts", new[] { "Tag_Id" });
            DropIndex("Blog.Posts", new[] { "Category_Id" });
            DropTable("Blog.TagPosts");
            DropTable("Blog.Tags");
            DropTable("Blog.Posts");
            DropTable("Blog.Categories");
        }
    }
}
