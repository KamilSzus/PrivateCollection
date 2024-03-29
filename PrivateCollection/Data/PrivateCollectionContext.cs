﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivateCollection.Models;
using System.Reflection.Metadata;

namespace PrivateCollection.Data
{
    public class PrivateCollectionContext : IdentityDbContext<User>
    {
        public PrivateCollectionContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BoardGameGenre> BoardGameGenres { get; set; }
        public DbSet<BoardGameStats> BoardGameStats { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookGenre>()
                    .HasKey(bg => new { bg.BookId, bg.GenereId });
            modelBuilder.Entity<BookGenre>()
                    .HasOne(b => b.Book)
                    .WithMany(bg => bg.BookGenres)
                    .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookGenre>()
                    .HasOne(b => b.Genre)
                    .WithMany(bg => bg.BookGenres)
                    .HasForeignKey(g => g.GenereId);

            modelBuilder.Entity<BoardGameGenre>()
                    .HasKey(bgg => new { bgg.BoardGameId, bgg.GenereId });
            modelBuilder.Entity<BoardGameGenre>()
                    .HasOne(bg => bg.BoardGame)
                    .WithMany(bgg => bgg.BoardGameGenre)
                    .HasForeignKey(bg => bg.BoardGameId);
            modelBuilder.Entity<BoardGameGenre>()
                    .HasOne(b => b.Genre)
                    .WithMany(bgg => bgg.BoardGameGenres)
                    .HasForeignKey(g => g.GenereId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
