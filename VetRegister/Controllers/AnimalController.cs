using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Animal;

namespace VetRegister.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService animalService;
        private readonly ISpecieService specieService;
        private readonly IOwnerService ownerService;
        private readonly IDoctorService doctorService;


        public AnimalController(IAnimalService animalService, ISpecieService specieService, IOwnerService ownerService, IDoctorService doctorService)
        {
            this.animalService = animalService;
            this.specieService = specieService;
            this.ownerService = ownerService;
            this.doctorService = doctorService;
        }

        public IActionResult Add()
        {
            return View(new AnimalFormModel
            {
                Species = this.animalService.GetAnimalSpecies()
            });
        }

        [HttpPost]
        public IActionResult Add(AnimalFormModel modelAnimal)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //if (userId == null)
            //{
            //    return BadRequest();
            //}

            if (!ModelState.IsValid)
            {
                modelAnimal.Species = this.animalService.GetAnimalSpecies();
                return View(modelAnimal);
            }

            if (!specieService.SpecieIdExists(modelAnimal.SpecieId))
            {
                return BadRequest();
            }

            animalService.Add(modelAnimal, userId);

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var ownerId = ownerService.GetOwnerId(userId);
            var currentAnimal = animalService.GetAnimalIncludeOwner(id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.Owner.Id != ownerId)
            //    {
            //    return BadRequest();
            //}

            return View(new AnimalFormModel
            {
                Name = currentAnimal.Name,
                DateOfBirth = currentAnimal.DateOfBirth.ToString("d"),
                SpecieId = currentAnimal.SpecieId,
                Species = this.animalService.GetAnimalSpecies(),
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, AnimalFormModel modelAnimal)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var ownerId = ownerService.GetOwnerId(userId);
            var currentAnimal = animalService.GetAnimalIncludeOwner(id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.Owner.Id != ownerId)
            //{
            //    return BadRequest();
            //}

            animalService.Edit(currentAnimal, modelAnimal);

            return RedirectToAction("All");
        }


        public IActionResult Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var ownerId = ownerService.GetOwnerId(userId);
            var currentAnimal = animalService.GetAnimalIncludeOwner(id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.Owner.Id != ownerId)
            //{
            //    return BadRequest();
            //}

            return View(new AnimalViewModel
            {
                Id = currentAnimal.Id,
                Name = currentAnimal.Name,
                DateOfBirth = currentAnimal.DateOfBirth.ToString("d"),
                Age = (DateTime.UtcNow.Year - currentAnimal.DateOfBirth.Year).ToString(),
                SpecieId = currentAnimal.SpecieId,
                SpecieName = specieService.GetSpecieName(currentAnimal.SpecieId),
                Procedures = animalService.GetAnimalProcedures(currentAnimal.Id)
            });
        }


        public IActionResult Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ownerId = ownerService.GetOwnerId(userId);
            var currentAnimal = animalService.GetAnimalIncludeOwner(id);

            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.OwnerId != ownerId)
            //{
            //    return BadRequest();
            //}

            animalService.Delete(currentAnimal);

            return RedirectToAction("All");
        }


        public IActionResult All(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter)
        {
            return View(animalService.AllAnimals(nameFilter, specieFilter, dateOfBirthFilter, ageFilter));
        }
    }
}
