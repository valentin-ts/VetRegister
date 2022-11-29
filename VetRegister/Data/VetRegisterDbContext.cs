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
        public DbSet<Exam> Exams { get; init; }
        public DbSet<Procedure> Procedures { get; init; }
        public DbSet<Owner> Owners { get; init; }
        public DbSet<Doctor> Doctors { get; init; }
        public DbSet<Clinic> Clinics { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Person>(u => u.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Animal>()
                .HasOne(o => o.Owner)
                .WithMany(a => a.Animals)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Animal>()
                .HasOne(b => b.Breed)
                .WithMany(a => a.Animals)
                .HasForeignKey(b => b.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Doctor>()
                .HasOne(c => c.Clinic)
                .WithMany(d => d.Doctors)
                .HasForeignKey(c => c.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exam>()
                .HasOne(a => a.Animal)
                .WithMany(e => e.Exams)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exam>()
                .HasOne(d => d.Doctor)
                .WithMany(e => e.Exams)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exam>()
                .HasOne(p => p.Procedure)
                .WithMany(a => a.Exams)
                .HasForeignKey(p => p.ProcedureId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
