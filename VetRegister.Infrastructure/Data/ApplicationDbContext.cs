using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using VetRegister.Infrastructure.Data.Models;
using VetRegister.Infrastructure.Data.SeedDb;

namespace VetRegister.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<Clinic> Clinics { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Procedure> Procedures { get; set; } = null!;
        public DbSet<Specie> Species { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var seedData = new SeedData();

            builder.Entity<Specie>()
                .HasData(seedData.Dog, seedData.Cat, seedData.Fish, seedData.Bird);

            builder.Entity<IdentityUser>()
                .HasData(seedData.IdentityUserOwner1, seedData.IdentityUserOwner2, seedData.IdentityUserDoctor1, seedData.IdentityUserDoctor2);

            builder.Entity<Clinic>()
                .HasData(seedData.Clinic1, seedData.Clinic2);

            builder.Entity<Owner>()
                .HasData(seedData.Owner1, seedData.Owner2);

            builder.Entity<Doctor>()
                .HasData(seedData.Doctor1, seedData.Doctor2);

            builder.Entity<Animal>()
                .HasData(seedData.Animal1, seedData.Animal2, seedData.Animal3, seedData.Animal4);

            builder.Entity<Procedure>()
                .HasData(seedData.Procedure1, seedData.Procedure2, seedData.Procedure3, seedData.Procedure4);


            builder.Entity<Animal>()
                .HasOne(o => o.Owner)
                .WithMany(a => a.Animals)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Animal>()
                .HasOne(b => b.Specie)
                .WithMany(a => a.Animals)
                .HasForeignKey(b => b.SpecieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(c => c.Clinic)
                .WithMany(d => d.Doctors)
                .HasForeignKey(c => c.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Procedure>()
                .HasOne(a => a.Animal)
                .WithMany(e => e.Procedures)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Procedure>()
                .HasOne(d => d.Doctor)
                .WithMany(e => e.Procedures)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
