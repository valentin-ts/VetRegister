using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class SpecieService : ISpecieService
    {
        private readonly ApplicationDbContext data;

        public SpecieService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public bool IdExists(int specieId)
        {
            return this.data
                .Species
                .Any(b => b.Id == specieId);
        }

        public bool NameExists(string specieName)
        {
            return this.data
                .Species
                .Any(b => b.Name == specieName);
        }

        public string GetName(int specieId)
        {
            return this.data
                .Species
                .Find(specieId)!.Name;
        }

        public IEnumerable<SpecieViewModel> GetAll()
        {
            return this.data
                .Species
                .Select(a => new SpecieViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }

        public void Add(string newSpecieName)
        {
            var newSpecie = new Specie
            {
                Name = newSpecieName
            };

            this.data.Species.Add(newSpecie);
            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            Specie currentSpecie = this.data.Species.Find(id)!;
            this.data.Species.Remove(currentSpecie);
            this.data.SaveChanges();
        }

        public void Edit(Specie currentSpecie, SpecieFormModel modelSpecie)
        {
            currentSpecie.Name = modelSpecie.NewSpecieName;
            this.data.SaveChanges();
        }

        public Specie GetById(int id)
        {
            return this.data.Species.Find(id)!;
        }
    }
}
