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

        public void Add(string NewSpecieName);

        public void Delete(int id);

        public void Edit(int id, SpecieFormModel modelSpecie);

        public Specie FindById(int id);
    }
}
