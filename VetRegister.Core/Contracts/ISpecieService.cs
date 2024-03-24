using VetRegister.Core.Models.Specie;

namespace VetRegister.Core.Contracts
{
    public interface ISpecieService
    {
        public bool SpecieIdExists(int specieId);

        public string GetSpecieName(int specieId);

        public IEnumerable<SpecieViewModel> GetAllAnimalSpecies();

        public void Add(string specieName);

        public void Delete(int Id);

        public void Edit(int Id, SpecieFormModel modelSpecie);
    }
}
