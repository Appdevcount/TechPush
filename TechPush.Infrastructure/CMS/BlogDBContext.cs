using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPush.Core;
using TechPush.Core.CMS;

namespace TechPush.Infrastructure.CMS
{

    public class BlogDBContext : DbContext
    {
        public BlogDBContext() : base("CMS")
        {

        }

        //Faced this issue in View model - https://msdn.microsoft.com/en-us/magazine/dn166926.aspx?f=255&MSPPError=-2147217396


        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<HotNews> HotNews { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Blog");
            base.OnModelCreating(modelBuilder);
        }

    }


}
