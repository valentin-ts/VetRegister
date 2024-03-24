using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly ISpecieService specieService;

        public SpecieController(ApplicationDbContext data, ISpecieService specieService)
        {
            this.data = data;
            this.specieService = specieService;
        }

        //[Authorize]
        public IActionResult All()
        {
            return View(new SpecieFormModel
            {
                AllSpeciesList = specieService.GetAllAnimalSpecies()
            });
        }

        [HttpPost]
        public IActionResult All(SpecieFormModel modelSpecie)
        {
            if (this.data.Species.Any(b => b.Name == modelSpecie.NewSpecieName))
            {
                this.ModelState.AddModelError(nameof(Specie.Id), "Specie already exists.");
                //return RedirectToAction("Exists", "Specie");  //Make a controller for this
            }

            if (!ModelState.IsValid)
            {
                modelSpecie.AllSpeciesList = specieService.GetAllAnimalSpecies();
                return View(modelSpecie);
            }

            specieService.Add(modelSpecie.NewSpecieName);

            return RedirectToAction("All");
        }


        public IActionResult Delete(int id)
        {
            if (!specieService.SpecieIdExists(id))
            {
                return BadRequest();
            }
            specieService.Delete(id);
            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            if (!specieService.SpecieIdExists(id))
            {
                return BadRequest();
            }

            var currentSpecie = this.data.Species.Find(id);
            return View(new SpecieFormModel
            {
                NewSpecieName = currentSpecie.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, SpecieFormModel modelSpecie)
        {
            if (!ModelState.IsValid)
            {
                return View(modelSpecie);
            }

            specieService.Edit(id, modelSpecie);

            return RedirectToAction("All");
        }
    }
}
