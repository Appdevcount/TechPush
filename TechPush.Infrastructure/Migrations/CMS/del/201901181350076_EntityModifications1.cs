namespace TechPush.Infrastructure.Migrations.CMS
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModifications1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Blog.Posts", "Category_Id", "Blog.Categories");
            RenameIndex(table: "Blog.Posts", name: "IX_Category_Id", newName: "IX_Category_CategoryId");
            RenameColumn(table: "Blog.Posts", name: "Category_Id", newName: "Category_CategoryId");
            DropPrimaryKey("Blog.Categories");
            DropColumn("Blog.Categories", "Id");
            AddColumn("Blog.Categories", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("Blog.Categories", "CategoryId");
            AddForeignKey("Blog.Posts", "Category_CategoryId", "Blog.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            //AddColumn("Blog.Categories", "Id", c => c.Int(nullable: false, identity: true));
            //DropForeignKey("Blog.Posts", "Category_CategoryId", "Blog.Categories");
            //DropPrimaryKey("Blog.Categories");
            //DropColumn("Blog.Categories", "CategoryId");
            //AddPrimaryKey("Blog.Categories", "Id");
            //RenameIndex(table: "Blog.Posts", name: "IX_Category_CategoryId", newName: "IX_Category_Id");
            //RenameColumn(table: "Blog.Posts", name: "Category_CategoryId", newName: "Category_Id");
            //AddForeignKey("Blog.Posts", "Category_Id", "Blog.Categories", "Id");
        }
    }
}
