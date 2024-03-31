using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .FirstOrDefault(b => b.Id == specieId).Name;
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

        public void Add(string specieName)
        {
            var newSpecie = new Specie
            {
                Name = specieName
            };

            this.data.Species.Add(newSpecie);
            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            var currentSpecie = this.data.Species.Find(id);
            this.data.Species.Remove(currentSpecie);
            this.data.SaveChanges();
        }

        public void Edit(int id, SpecieFormModel modelSpecie)
        {
            var currentSpecie = this.data.Species.Find(id);
            currentSpecie.Name = modelSpecie.NewSpecieName;
            this.data.SaveChanges();
        }

        public Specie? FindById(int id)
        {
            return this.data.Species.Find(id);
        }
    }
}
