using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Procedure;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IAnimalService
    {
        public Task AddAnimalAsync(AnimalFormModel modelAnimal, string userId);

        public Task EditAnimalAsync(Animal currentAnimal, AnimalFormModel modelAnimal);

        public Task<IEnumerable<SpecieViewModel>> GetAnimalSpeciesAsync();

        public Task<Animal?> GetAnimalAsync(int id);

        public Task<Animal?> GetAnimalIncludeOwnerAsync(int id);

        public Task DeleteAnimalAsync(Animal currentAnimal);

        public Task<IEnumerable<ProcedureViewModel>> GetAnimalProceduresAsync(int animalId);

        public Task<AllAnimalsQueryModel> GetAllAnimalsAsync(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter); 
    }
}
