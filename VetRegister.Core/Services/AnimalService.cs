using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly ApplicationDbContext data;
        private readonly IOwnerService ownerService;

        public AnimalService(ApplicationDbContext data, IOwnerService ownerService)
        {
            this.data = data;
            this.ownerService = ownerService;
        }

        public void Add(AnimalFormModel modelAnimal, string userId)
        {
            Animal newAnimal = new Animal
            {
                Name = modelAnimal.Name,
                Owner = data.Owners.FirstOrDefault(o => o.User.Id == userId)!,
                DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth),
                SpecieId = modelAnimal.SpecieId
            };

            data.Animals.Add(newAnimal);
            data.SaveChanges();
        }

        public IEnumerable<AnimalSpecieViewModel> GetAnimalSpecies()
        {
            return this.data
                .Species
                .Select(a => new AnimalSpecieViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }

        public void Edit(Animal currentAnimal, AnimalFormModel modelAnimal)
        {
            currentAnimal.Name = modelAnimal.Name;
            currentAnimal.DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth);
            currentAnimal.SpecieId = modelAnimal.SpecieId;

            this.data.SaveChanges();
        }

        public void Delete(Animal currentAnimal)
        {
            this.data.Animals.Remove(currentAnimal);
            this.data.SaveChanges();
        }

        public IQueryable<Animal> GetAnimalsAsQueryable()
        {
            return this.data.Animals.AsQueryable();
        }

        public Animal? GetAnimal(int id)
        {
            return this.data
                .Animals
                .FirstOrDefault(a => a.Id == id);
        }

        public Animal? GetAnimalIncludeOwner(int id)
        {
            return this.data
                .Animals
                .Include(a => a.Owner)
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<ProcedureViewModel> GetAnimalProcedures(int animalId)
        {
            return this.data
                .Procedures
                .Where(p => p.AnimalId == animalId)
                    .Select(p => new ProcedureViewModel
                    {
                        AnimalName = p.Animal.Name,
                        Description = p.Description,
                        CreatedOn = p.CreatedOn.ToString("d"),
                        DoctorName = p.Doctor.Name
                    })
                .ToList();
        }

        public AllAnimalsQueryModel AllAnimals(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter)
        {
            var animalsQuery = GetAnimalsAsQueryable();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                animalsQuery = animalsQuery.Where(a => a.Name.Contains(nameFilter));
            }

            if (specieFilter != null)
            {
                animalsQuery = animalsQuery.Where(a => a.Specie.Id == specieFilter);
            }

            if (DateTime.TryParse(dateOfBirthFilter, out DateTime dateOfBirth))
            {
                animalsQuery = animalsQuery.Where(a => a.DateOfBirth == DateTime.Parse(dateOfBirthFilter));
            }

            if (int.TryParse(ageFilter, out int parsedAge))
            {
                animalsQuery = animalsQuery.Where(a => (DateTime.UtcNow.Year - a.DateOfBirth.Year) == parsedAge);
            }

            var filteredAnimals = animalsQuery
                //.Where(a => a.OwnerId == ownerId)  // Owner filter should be put if we want to see only owners animals, not all
                .Select(a => new AnimalViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth.ToString("d"),
                    Age = (DateTime.UtcNow.Year - a.DateOfBirth.Year).ToString(),
                    SpecieId = a.SpecieId,
                    SpecieName = a.Specie.Name
                })
                .ToList();

            var animalSpecies = GetAnimalSpecies();

            return (new AllAnimalsQueryModel
            {
                Animals = filteredAnimals,
                Species = animalSpecies
            });
        }
    }
}
