using Microsoft.AspNetCore.Identity;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Specie Dog { get; set; }

        public Specie Cat { get; set; }

        public Specie Fish { get; set; }

        public Specie Bird { get; set; }

        public Clinic Clinic1 { get; set; }

        public Clinic Clinic2 { get; set; }

        public IdentityUser IdentityUserOwner1 { get; set; }

        public IdentityUser IdentityUserOwner2 { get; set; }

        public IdentityUser IdentityUserDoctor1 { get; set; }

        public IdentityUser IdentityUserDoctor2 { get; set; }

        public Owner Owner1 { get; set; }

        public Owner Owner2 { get; set; }

        public Doctor Doctor1 { get; set; }

        public Doctor Doctor2 { get; set; }

        public Animal Animal1 { get; set; }

        public Animal Animal2 { get; set; }

        public Animal Animal3 { get; set; }

        public Animal Animal4 { get; set; }

        public Procedure Procedure1 { get; set; }

        public Procedure Procedure2 { get; set; }

        public Procedure Procedure3 { get; set; }

        public Procedure Procedure4 { get; set; }



        public SeedData()
        {
            SeedSpecies();
            SeedClinics();
            SeedIdentityUsers();
            SeedOwners();
            SeedDoctors();
            SeedAnimals();
            SeedProcedures();
        }


        private void SeedSpecies()
        {
            Dog = new Specie()
            {
                Id = 1,
                Name = "Dog"
            };

            Cat = new Specie()
            {
                Id = 2,
                Name = "Cat"
            };

            Fish = new Specie()
            {
                Id = 3,
                Name = "Fish"
            };

            Bird = new Specie()
            {
                Id = 4,
                Name = "Bird"
            };
        }

        private void SeedClinics()
        {
            Clinic1 = new Clinic()
            {
                Id = 1,
                Name = "Clinic1",
                PhoneNumber = "0880000001"
            };

            Clinic2 = new Clinic()
            {
                Id = 2,
                Name = "Clinic2",
                PhoneNumber = "0880000002"
            };
        }

        private void SeedIdentityUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUserOwner1 = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "owner1@vet.com",
                NormalizedUserName = "owner1@vet.com",
                Email = "owner1@vet.com",
                NormalizedEmail = "owner1@vet.com"
            };
            IdentityUserOwner1.PasswordHash =
                 hasher.HashPassword(IdentityUserOwner1, "111111");

            IdentityUserOwner2 = new IdentityUser()
            {
                Id = "53ae2865-4a73-4974-ac06-eff5bf01b7f6",
                UserName = "owner2@vet.com",
                NormalizedUserName = "owner2@vet.com",
                Email = "owner2@vet.com",
                NormalizedEmail = "owner2@vet.com"
            };
            IdentityUserOwner2.PasswordHash =
                 hasher.HashPassword(IdentityUserOwner2, "111111");

            IdentityUserDoctor1 = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "doctor1@vet.com",
                NormalizedUserName = "doctor1@vet.com",
                Email = "doctor1@vet.com",
                NormalizedEmail = "doctor1@vet.com"
            };
            IdentityUserDoctor1.PasswordHash =
            hasher.HashPassword(IdentityUserDoctor1, "111111");

            IdentityUserDoctor2 = new IdentityUser()
            {
                Id = "9c862997-7dff-4c65-9510-8e0b29e1e877",
                UserName = "doctor2@vet.com",
                NormalizedUserName = "doctor2@vet.com",
                Email = "doctor2@vet.com",
                NormalizedEmail = "doctor2@vet.com"
            };
            IdentityUserDoctor2.PasswordHash =
            hasher.HashPassword(IdentityUserDoctor2, "111111");
        }

        private void SeedOwners()
        {
            Owner1 = new Owner()
            {
                Id = 1,
                UserId = IdentityUserOwner1.Id,
                Address = "Owner1 Address",
                PhoneNumber = "0880000003"
            };

            Owner2 = new Owner()
            {
                Id = 2,
                UserId = IdentityUserOwner2.Id,
                Address = "Owner2 Address",
                PhoneNumber = "0880000004"
            };
        }


        private void SeedDoctors()
        {
            Doctor1 = new Doctor()
            {
                Id = 1,
                UserId = IdentityUserDoctor1.Id,
                ClinicId = Clinic1.Id
            };

            Doctor2 = new Doctor()
            {
                Id = 2,
                UserId = IdentityUserDoctor2.Id,
                ClinicId = Clinic2.Id
            };
        }

        private void SeedAnimals()
        {
            Animal1 = new Animal()
            {
                Id = 1,
                Name = "Dog1",
                GenderIsMale = true,
                DateOfBirth = Convert.ToDateTime("01.01.2021"),
                //DateOfBirth = DateTime.Now,
                SpecieId = 1,
                OwnerId = 1
            };

            Animal2 = new Animal()
            {
                Id = 2,
                Name = "Cat1",
                GenderIsMale = false,
                DateOfBirth = Convert.ToDateTime("01.01.2022"),
                //DateOfBirth = DateTime.Now,
                SpecieId = 2,
                OwnerId = 1
            };

            Animal3 = new Animal()
            {
                Id = 3,
                Name = "Fish1",
                GenderIsMale = false,
                DateOfBirth = Convert.ToDateTime("01.01.2023"),
                //DateOfBirth = DateTime.Now,
                SpecieId = 3,
                OwnerId = 2
            };

            Animal4 = new Animal()
            {
                Id = 4,
                Name = "Bird1",
                GenderIsMale = false,
                DateOfBirth = Convert.ToDateTime("01.01.2024"),
                //DateOfBirth = DateTime.Now,
                SpecieId = 4,
                OwnerId = 2
            };


        }

        private void SeedProcedures()
        {
            Procedure1 = new Procedure()
            {
                Id = 1,
                Description = "Operation",
                CreatedOn = DateTime.Now,
                AnimalId = Animal1.Id,
                DoctorId = Doctor1.Id
            };

            Procedure2 = new Procedure()
            {
                Id = 2,
                Description = "Vaccination",
                CreatedOn = DateTime.Now,
                AnimalId = Animal2.Id,
                DoctorId = Doctor1.Id
            };

            Procedure3 = new Procedure()
            {
                Id = 3,
                Description = "Blood Test",
                CreatedOn = DateTime.Now,
                AnimalId = Animal3.Id,
                DoctorId = Doctor2.Id
            };

            Procedure4 = new Procedure()
            {
                Id = 4,
                Description = "Nail Trimming",
                CreatedOn = DateTime.Now,
                AnimalId = Animal4.Id,
                DoctorId = Doctor2.Id
            };
        }









    }
}
