using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatGenre.Models
{
    public class WhatGenreContext : DbContext
    {
        public WhatGenreContext(DbContextOptions<WhatGenreContext> options) : base(options)
        {
            // makes sure database is created first before making queries.
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }

    }
}
