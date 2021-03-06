﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class MyContext<T> : DbContext where T : class
    {
        public MyContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=WebDB;Integrated Security=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(p => p.Articles)
                .WithRequired(p => p.Author);
        }

        //public DbSet<Article> Articles { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public DbSet<T> Get { get; set; }
    }
}
