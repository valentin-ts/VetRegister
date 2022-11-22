using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetRegister.Data.Models;

namespace VetRegister.Data
{
    public class VetRegisterDbContext : IdentityDbContext
    {
        public VetRegisterDbContext(DbContextOptions<VetRegisterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; init; }

        public DbSet<Breed> Breeds { get; init; }

        public DbSet<Doctor> Doctors{ get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasOne(b => b.Breed)
                .WithMany(a => a.Animals)
                .HasForeignKey(b => b.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(builder);
        }

    }
}
