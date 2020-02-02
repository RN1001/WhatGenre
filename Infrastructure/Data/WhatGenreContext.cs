using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class WhatGenreContext : DbContext
    {
        public WhatGenreContext(DbContextOptions<WhatGenreContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasMany(a => a.Addresses)
              .WithOne(u => u.User);

            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<PostComment>().HasKey(pc => new { pc.PostId, pc.CommentId });

            modelBuilder.Entity<PostComment>()
                .HasOne(p => p.Post)
                .WithMany(p => p.PostComments)
                .HasForeignKey(p => p.PostId);

            modelBuilder.Entity<PostComment>()
                .HasOne(c => c.Comment)
                .WithMany(pc => pc.PostComments)
                .HasForeignKey(c => c.CommentId);

        }

    }
}
