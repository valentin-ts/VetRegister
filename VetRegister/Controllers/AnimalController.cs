using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Add()
        {
            return View(new AnimalFormModel
            {
                Species = await animalService.GetAnimalSpeciesAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AnimalFormModel modelAnimal)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                modelAnimal.Species = await animalService.GetAnimalSpeciesAsync();
                return View(modelAnimal);
            }

            if (await specieService.SpecieIdExistsAsync(modelAnimal.SpecieId) == false)
            {
                return BadRequest();
            }

            animalService.AddAnimalAsync(modelAnimal, userId);

            return RedirectToAction("All");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest();
            }

            var ownerId = await ownerService.GetOwnerIdAsync(userId);
            if (ownerId == null)
            {
                return BadRequest();
            }

            var currentAnimal = await animalService.GetAnimalIncludeOwnerAsync(id);
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
                Species = await animalService.GetAnimalSpeciesAsync(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AnimalFormModel modelAnimal)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest();
            }

            var ownerId = ownerService.GetOwnerIdAsync(userId);
            if (ownerId == null)
            {
                return BadRequest();
            }

            var currentAnimal = await animalService.GetAnimalIncludeOwnerAsync(id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.Owner.Id != ownerId)
            //{
            //    return BadRequest();
            //}

            await animalService.EditAnimalAsync(currentAnimal, modelAnimal);

            return RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest();
            }

            //Any doctor should be able to iew details, so he can add procedure, not just owner !!!

            var currentAnimal = await animalService.GetAnimalIncludeOwnerAsync(id);
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
                SpecieName = await specieService.GetSpecieNameAsync(currentAnimal.SpecieId),
                Procedures = await animalService.GetAnimalProceduresAsync(currentAnimal.Id)
            });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest();
            }

            var ownerId = await ownerService.GetOwnerIdAsync(userId);
            if (ownerId == null)
            {
                return BadRequest();
            }

            var currentAnimal = await animalService.GetAnimalIncludeOwnerAsync(id);
            if (currentAnimal == null)
            {
                return BadRequest();
            }

            //if (currentAnimal.OwnerId != ownerId)
            //{
            //    return BadRequest();
            //}

            await animalService.DeleteAnimalAsync(currentAnimal);

            return RedirectToAction("All");
        }


        public async Task<IActionResult> All(string? nameFilter, int? specieFilter, string? dateOfBirthFilter, string? ageFilter)
        {
            return View( await animalService.GetAllAnimalsAsync(nameFilter, specieFilter, dateOfBirthFilter, ageFilter));
        }
    }
}
