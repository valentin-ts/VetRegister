using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface ISpecieService
    {
        public Task<bool> SpecieIdExistsAsync(int specieId);

        public Task<bool> SpecieNameExistsAsync(string specieName);

        public Task<string> GetSpecieNameAsync(int specieId);

        public Task<IEnumerable<SpecieViewModel>> GetAllSpeciesAsync();

        public Task AddSpecieAsync(string newSpecieName);

        public Task DeleteSpecieAsync(int id);

        public Task EditSpecieAsync(Specie currentSpecie, SpecieFormModel modelSpecie);

        public Task<Specie> GetSpecieByIdAsync(int id);
    }
}
