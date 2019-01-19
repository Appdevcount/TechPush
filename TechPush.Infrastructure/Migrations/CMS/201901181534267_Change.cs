namespace TechPush.Infrastructure.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Blog.Tags", "Post_PostId", "Blog.Posts");
            DropIndex("Blog.Tags", new[] { "Post_PostId" });
            CreateTable(
                "Blog.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("Blog.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("Blog.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
            DropColumn("Blog.Tags", "Post_PostId");
        }
        
        public override void Down()
        {
            AddColumn("Blog.Tags", "Post_PostId", c => c.Int());
            DropForeignKey("Blog.TagPosts", "Post_PostId", "Blog.Posts");
            DropForeignKey("Blog.TagPosts", "Tag_TagId", "Blog.Tags");
            DropIndex("Blog.TagPosts", new[] { "Post_PostId" });
            DropIndex("Blog.TagPosts", new[] { "Tag_TagId" });
            DropTable("Blog.TagPosts");
            CreateIndex("Blog.Tags", "Post_PostId");
            AddForeignKey("Blog.Tags", "Post_PostId", "Blog.Posts", "PostId");
        }
    }
}
