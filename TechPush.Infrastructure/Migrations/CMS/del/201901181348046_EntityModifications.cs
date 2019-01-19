namespace TechPush.Infrastructure.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions");
            DropIndex("Blog.Posts", new[] { "Region_RegionId" });
            AlterColumn("Blog.Posts", "Region_RegionId", c => c.Int());
            CreateIndex("Blog.Posts", "Region_RegionId");
            AddForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions", "RegionId");
        }
        
        public override void Down()
        {
            DropForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions");
            DropIndex("Blog.Posts", new[] { "Region_RegionId" });
            AlterColumn("Blog.Posts", "Region_RegionId", c => c.Int(nullable: false));
            CreateIndex("Blog.Posts", "Region_RegionId");
            AddForeignKey("Blog.Posts", "Region_RegionId", "Blog.Regions", "RegionId", cascadeDelete: true);
        }
    }
}
