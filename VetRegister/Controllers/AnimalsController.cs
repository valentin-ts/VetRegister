using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Animals;
using VetRegister.Models.Exams;
using VetRegister.Services.Persons;

namespace VetRegister.Controllers
{
    [Authorize]
    public class AnimalsController : Controller
    {
        private readonly VetRegisterDbContext data;
        private readonly IPersonService person;

        public AnimalsController(VetRegisterDbContext data, IPersonService person)
        {
            this.data = data;
            this.person = person;
        }

        public IActionResult Add()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }

            return View(new AnimalFormModel
            {
                Breeds = this.GetAnimalBreeds()
            });
        }

        [HttpPost]
        public IActionResult Add(AnimalFormModel modelAnimal)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                modelAnimal.Breeds = this.GetAnimalBreeds();
                return View(modelAnimal);
            }

            if (!this.data.Breeds.Any(b => b.Id == modelAnimal.BreedId))
            {
                return BadRequest();
            }

            var newAnimal = new Animal
            {
                Name = modelAnimal.Name,
                Owner = data.Owners.FirstOrDefault(o => o.PersonId == userId),
                DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth),
                BreedId = modelAnimal.BreedId
            };

            data.Animals.Add(newAnimal);
            data.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }
            var ownerId = data.Owners.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentAnimal = this.data.Animals.Find(id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            if (currentAnimal.OwnerId != ownerId)
            {
                return BadRequest();
            }

            return View(new AnimalFormModel
            {
                Name = currentAnimal.Name,
                DateOfBirth = currentAnimal.DateOfBirth.ToString("d"),
                BreedId = currentAnimal.BreedId,
                Breeds = this.GetAnimalBreeds(),
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, AnimalFormModel modelAnimal)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }
            var ownerId = data.Owners.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentAnimal = this.data.Animals.Find(id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            if (currentAnimal.OwnerId != ownerId)
            {
                return BadRequest();
            }

            currentAnimal.Name = modelAnimal.Name;
            currentAnimal.DateOfBirth = DateTime.Parse(modelAnimal.DateOfBirth);
            currentAnimal.BreedId = modelAnimal.BreedId;

            this.data.SaveChanges();

            return RedirectToAction("All");
        }


        public IActionResult Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }
            var ownerId = data.Owners.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentAnimal = this.data.Animals.Find(id);
            //var currentAnimal = this.data.Animals.Include(a => a.Breed).Include(e => e.Exams).FirstOrDefault(a => a.Id == id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            if (currentAnimal.OwnerId != ownerId)
            {
                return BadRequest();
            }

            return View(new AnimalViewModel
            {
                Id = currentAnimal.Id,
                Name = currentAnimal.Name,
                DateOfBirth = currentAnimal.DateOfBirth.ToString("d"),
                Age = (DateTime.UtcNow.Year - currentAnimal.DateOfBirth.Year).ToString(),
                BreedId = currentAnimal.BreedId,
                BreedName = GetBreedName(currentAnimal.BreedId),
                Exams = GetAnimalExams(currentAnimal.Id)
            });
        }


        public IActionResult Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }
            var ownerId = data.Owners.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentAnimal = this.data.Animals.Find(id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            if (currentAnimal.OwnerId != ownerId)
            {
                return BadRequest();
            }

            this.data.Animals.Remove(currentAnimal);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }


        public IActionResult All(string nameFilter, string breedFilter, string dateOfBirthFilter, string ageFilter)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsOwner(userId))
            {
                return BadRequest();
            }
            var ownerId = data.Owners.FirstOrDefault(d => d.PersonId == userId).Id;


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

            DateTime dateOfBirth;
            if (DateTime.TryParse(dateOfBirthFilter, out dateOfBirth))
            {
                animalsQuery = animalsQuery.Where(a => a.DateOfBirth == DateTime.Parse(dateOfBirthFilter));
            }

            int parsedAge;
            if (int.TryParse(ageFilter, out parsedAge))
            {
                animalsQuery = animalsQuery.Where(a => (DateTime.UtcNow.Year - a.DateOfBirth.Year) == parsedAge);
            }

            var animals = animalsQuery
                .Where(a => a.OwnerId == ownerId)  // Owner filter - on forever :)
                .Select(a => new AnimalViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth.ToString("d"),
                    Age = (DateTime.UtcNow.Year - a.DateOfBirth.Year).ToString(),
                    BreedId = a.BreedId,
                    BreedName = a.Breed.Name
                })
                .ToList();

            var AnimalBreeds = this.data
                .Animals
                .Select(a => a.Breed.Name)
                .Distinct()
                .ToList();

            return View(new AllAnimalsQueryModel
            {
                Animals = animals,
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

        private IEnumerable<ExamViewModel> GetAnimalExams(int animalId)
        {
            return this.data
                .Exams
                .Where(e => e.AnimalId == animalId)
                .Select(e => new ExamViewModel
                {
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("d"),
                    DoctorName = e.Doctor.FullName
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
