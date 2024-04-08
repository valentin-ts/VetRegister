using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface ISpecieService
    {
        public bool IdExists(int specieId);

        public bool NameExists(string specieName);

        public string GetName(int specieId);

        public IEnumerable<SpecieViewModel> GetAll();

        public void Add(string newSpecieName);

        public void Delete(int id);

        public void Edit(Specie currentSpecie, SpecieFormModel modelSpecie);

        public Specie GetById(int id);
    }
}
