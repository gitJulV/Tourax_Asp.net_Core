using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tourax.Data.Entities;

namespace Tourax.Data
{
    public class TouraxDbContext : IdentityDbContext
    {
        public TouraxDbContext(DbContextOptions<TouraxDbContext> options): base(options)
        {
        }

        public DbSet<BobineEntity> Bobines { get; set; }
        public DbSet<MatiereEntity> Matieres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BobineEntity>().ToTable("Bobine");
            modelBuilder.Entity<MatiereEntity>().ToTable("Matiere");
            base.OnModelCreating(modelBuilder);
        }
    }
}
