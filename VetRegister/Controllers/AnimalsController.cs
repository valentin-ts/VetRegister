using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Animals;


namespace VetRegister.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly VetRegisterDbContext data;

        public AnimalsController(VetRegisterDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddAnimalFormModel
                {
                    Breeds = this.GetAnimalBreeds()
                }
            );
        }

        [HttpPost]
        public IActionResult Add(AddAnimalFormModel animal)
        {
            //check if BreedId exists in database
            if (!this.data.Breeds.Any(b => b.Id == animal.BreedId))
            {
                this.ModelState.AddModelError(nameof(animal.BreedId), "Breed does not exist.");
            }

            //check if model statie is invalid, add breeds again.
            if (!ModelState.IsValid)
            {
                animal.Breeds = this.GetAnimalBreeds();
                return View(animal);
            }

            var newAnimal = new Animal
            {
                Name = animal.Name,
                Owner = animal.Owner,
                Age = animal.Age,
                BreedId = animal.BreedId
            };

            data.Animals.Add(newAnimal);
            data.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult All(string nameFilter, string breedFilter, string ageFilter, string ownerFilter)
        {
            var animalsQuery = this.data.Animals.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                animalsQuery = animalsQuery.Where(a => a.Name.Contains(nameFilter));
            }

            if (!string.IsNullOrWhiteSpace(breedFilter))
            {
                animalsQuery = animalsQuery.Where(a => a.Breed.Name == breedFilter);
                //animalsQuery = animalsQuery.Where(a => a.Breed.Name.Contains(breedFilter));
            }

            int parsedAge;
            if (int.TryParse(ageFilter, out parsedAge))
            {
                animalsQuery = animalsQuery.Where(a => a.Age.Equals(parsedAge));
            }

            if (!string.IsNullOrWhiteSpace(ownerFilter))
            {
                animalsQuery = animalsQuery.Where(a => a.Owner.Contains(ownerFilter));
            }

            var animals =  animalsQuery
                .Select(a => new AnimalListingViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Owner = a.Owner,
                    Age = a.Age,
                    BreedId = a.BreedId,
                    BreedName = a.Breed.Name
                })
                .ToList();

            var AnimalBreeds = this.data
                .Animals
                .Select(a => a.Breed.Name)
                .Distinct()
                .ToList();
 
            //AnimalBreeds.Insert(0, null);

            return View(new AllAnimalsQueryModel 
            { 
                Animals = animals,
                //NameFilter = nameFilter,
                Breeds = AnimalBreeds
            });
        }



        private IEnumerable<AnimalBreedViewModel> GetAnimalBreeds()
        {
            return this.data
                .Breeds
                .Select(a => new AnimalBreedViewModel
                {
                    Id = a.Id,
                    Name = a.Name 
                })
                .ToList();
        }
    }
}
