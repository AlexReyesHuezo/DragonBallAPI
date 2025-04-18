﻿using Microsoft.EntityFrameworkCore;
using DragonBallAPI.Models;

namespace DragonBallAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Transformation> Transformations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Transformations)
                .WithOne(t => t.Character)
                .HasForeignKey(t => t.CharacterId);
            modelBuilder.Entity<Transformation>()
                .HasOne(t => t.Character)
                .WithMany(c => c.Transformations)
                .HasForeignKey(t => t.CharacterId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
