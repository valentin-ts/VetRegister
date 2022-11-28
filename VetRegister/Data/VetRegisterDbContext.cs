using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetRegister.Areas.Users.Data;
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
        //public DbSet<Person> Persons{ get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasOne(b => b.Breed)
                .WithMany(a => a.Animals)
                .HasForeignKey(b => b.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Person>()
            //    .HasOne<IdentityUser>()
            //    .WithOne()
            //    .HasForeignKey<Person>(u => u.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exam>()
                .HasOne(a => a.Animal)
                .WithMany(e => e.Exams)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Doctor>()
            //    .HasOne<Person>()
            //    .WithOne()
            //    .HasForeignKey<Doctor>(u => u.PersonId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Owner>()
            //    .HasOne<Person>()
            //    .WithOne()
            //    .HasForeignKey<Owner>(u => u.PersonId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
