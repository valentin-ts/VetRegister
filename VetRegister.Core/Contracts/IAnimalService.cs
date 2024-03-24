using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IAnimalService
    {
        public void Add(AnimalFormModel modelAnimal, string userId);

        public void Edit(Animal currentAnimal, AnimalFormModel modelAnimal);

        public IEnumerable<AnimalSpecieViewModel> GetAnimalSpecies();

        public Animal? GetAnimal(int id);

        public Animal? GetAnimalIncludeOwner(int id);

        public void Delete(Animal currentAnimal);

        public IQueryable<Animal> GetAnimalsAsQueryable();

        public IEnumerable<ProcedureViewModel> GetAnimalProcedures(int animalId);

        public AllAnimalsQueryModel AllAnimals(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter); 
    }
}
