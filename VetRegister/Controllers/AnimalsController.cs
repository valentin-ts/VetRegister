using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Animals;
using VetRegister.Models.Exams;

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
            return View(new AddAndEditAnimalFormModel
                {
                    Breeds = this.GetAnimalBreeds()
                }
            );
        }

        [HttpPost]
        public IActionResult Add(AddAndEditAnimalFormModel animal)
        {
            //check if BreedId exists in database
            if (!this.data.Breeds.Any(b => b.Id == animal.BreedId))
            {
                return BadRequest();
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

        public IActionResult Edit(int id)
        {
            //var currentAnimal = this.data.Animals.Find(id);
            var currentAnimal = this.data.Animals.Include(a => a.Breed).FirstOrDefault(a => a.Id == id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            return View(new AddAndEditAnimalFormModel
            {
                Name = currentAnimal.Name,
                Age = currentAnimal.Age,
                BreedId = currentAnimal.BreedId,
                Owner = currentAnimal.Owner,
                Breeds = this.GetAnimalBreeds(),
                BreedName = currentAnimal.Breed.Name
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, AddAndEditAnimalFormModel modelAnimal)
        {
            var currentAnimal = this.data.Animals.Find(id);

            currentAnimal.Owner = modelAnimal.Owner;
            currentAnimal.Name = modelAnimal.Name;
            currentAnimal.Age = modelAnimal.Age;
            currentAnimal.BreedId = modelAnimal.BreedId;

            this.data.SaveChanges();

            return RedirectToAction("All");
        }


        public IActionResult Details(int id)
        {
            //var currentAnimal = this.data.Animals.Find(id);
            var currentAnimal = this.data.Animals.Include(a => a.Breed).Include(e => e.Exams).FirstOrDefault(a => a.Id == id);



            if (currentAnimal == null)
            {
                return BadRequest();
            }

            return View(new AddAndEditAnimalFormModel
            {
                Name = currentAnimal.Name,
                Age = currentAnimal.Age,
                BreedId = currentAnimal.BreedId,
                Owner = currentAnimal.Owner,
                Breeds = this.GetAnimalBreeds(),
                BreedName = GetBreedName(currentAnimal.BreedId),
                AnimalId = currentAnimal.Id,
                Exams = GetAnimalExams(currentAnimal.Id),
            });
        }


        public IActionResult Delete(int id)
        {
            var currentAnimal = this.data.Animals.Find(id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            this.data.Animals.Remove(currentAnimal);
            this.data.SaveChanges();

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

        private IEnumerable<ExamFormModel> GetAnimalExams(int animalId)
        {
            return this.data
                .Exams
                .Where(e => e.AnimalId == animalId)
                .Select(e => new ExamFormModel
                {
                    Text = e.Text,
                    CreatedOn = e.CreatedOn
                })
                .ToList();
        }

        private string GetBreedName(int breedId)
        {
            return this.data
                .Breeds
                .FirstOrDefault(b => b.Id == breedId).Name;
        }
    }
}
