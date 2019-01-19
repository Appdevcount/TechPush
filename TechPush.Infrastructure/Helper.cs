using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPush.Core;
using TechPush.Infrastructure.CMS;
using TechPush.Infrastructure.Migrations.CMS;

namespace TechPush.Infrastructure
{
    public class Helper
    {
        
        public void seed()
        {
            BlogDBContext context= new BlogDBContext();
            context.Regions.AddOrUpdate(x => x.RegionName,
        new Region() { RegionId = 1, RegionName = "R1", Enable = true },
        new Region() { RegionId = 2, RegionName = "R1", Enable = true },
        new Region() { RegionId = 4, RegionName = "R1", Enable = true }
        );

            context.Categories.AddOrUpdate(x => x.CategoryId,
                new Category()
                {
                    CategoryId = 1,
                    Name = "C1",
                    Description = "fb",
                    UrlSlug = "bx",
                    Enable = true
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "C2",
                    Description = "fb",
                    UrlSlug = "bx",
                    Enable = true
                }
                );

            context.Tags.AddOrUpdate(x => x.TagId,
                new Tag()
                {
                    TagId = 1,
                    Name = "C1",
                    UrlSlug = "sfg",
                    Description = "sdf"
                },
                new Tag()
                {
                    TagId = 2,
                    Name = "C2",
                    UrlSlug = "daf",
                    Description = "asf"
                }
                );

            context.SaveChanges();
        }

    }
}
