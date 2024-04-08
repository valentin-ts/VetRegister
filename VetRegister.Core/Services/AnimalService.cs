using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Procedure;
using VetRegister.Core.Models.Specie;
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

        public async Task AddAnimalAsync(AnimalFormModel modelAnimal, string userId)
        {
            Animal newAnimal = new Animal
            {
                Name = modelAnimal.Name,
                Owner = data.Owners.FirstOrDefault(o => o.User.Id == userId)!,
                DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth),
                SpecieId = modelAnimal.SpecieId
            };

            await data.Animals.AddAsync(newAnimal);
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpecieViewModel>> GetAnimalSpeciesAsync()
        {
            return await data
                .Species
                .Select(a => new SpecieViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task EditAnimalAsync(Animal currentAnimal, AnimalFormModel modelAnimal)
        {
            currentAnimal.Name = modelAnimal.Name;
            currentAnimal.DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth);
            currentAnimal.SpecieId = modelAnimal.SpecieId;

            await data.SaveChangesAsync();
        }

        public async Task DeleteAnimalAsync(Animal currentAnimal)
        {
            data.Animals.Remove(currentAnimal);
            await data.SaveChangesAsync();
        }


        public async Task<Animal?> GetAnimalAsync(int id)
        {
            return await data
                .Animals
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Animal?> GetAnimalIncludeOwnerAsync(int id)
        {
            return await data
                .Animals
                .Include(a => a.Owner)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ProcedureViewModel>> GetAnimalProceduresAsync(int animalId)
        {
            return await data
                .Procedures
                .Where(p => p.AnimalId == animalId)
                .Select(p => new ProcedureViewModel
                {
                    AnimalName = p.Animal.Name,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn.ToString("d"),
                    DoctorName = p.Doctor.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AllAnimalsQueryModel> GetAllAnimalsAsync(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter)
        {
            var animalsQuery = data.Animals.AsQueryable();

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

            var filteredAnimals = await animalsQuery
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
                .ToListAsync();

            var animalSpecies = await GetAnimalSpeciesAsync();

            return (new AllAnimalsQueryModel
            {
                Animals = filteredAnimals,
                Species = animalSpecies
            });
        }
    }
}
