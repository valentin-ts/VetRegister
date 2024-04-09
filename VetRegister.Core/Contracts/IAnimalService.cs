using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Procedure;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IAnimalService
    {
        public Task<bool>AnimalIdExistsAsync(int id);

        public Task AddAnimalAsync(AnimalFormModel modelAnimal, string userId);

        public Task EditAnimalAsync(int id, AnimalFormModel modelAnimal);

        public Task<Animal?> GetAnimalAsync(int id);

        public Task<Animal?> GetAnimalIncludeOwnerAsync(int id);

        public Task DeleteAnimalAsync(int id);

        public Task<IEnumerable<ProcedureViewModel>> GetAnimalProceduresAsync(int id);

        public Task<AllAnimalsQueryModel> GetAllAnimalsAsync(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter); 
    }
}
