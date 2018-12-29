﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPush.Core;

namespace TechPush.Infrastructure.CMS
{

    public class BlogDBContext : DbContext
    {
        public BlogDBContext() : base("CMS")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Blog");
            base.OnModelCreating(modelBuilder);
        }

    }

}
