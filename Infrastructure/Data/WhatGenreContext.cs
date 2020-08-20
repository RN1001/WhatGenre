using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class WhatGenreContext : IdentityDbContext<User, ApplicationRole, string>
    {
        public WhatGenreContext(DbContextOptions<WhatGenreContext> options) : base(options)
        {
           
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
              .HasMany(a => a.Addresses)
              .WithOne(u => u.User);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Posts)
                .WithOne(u => u.User);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post);


        }

    }
}
