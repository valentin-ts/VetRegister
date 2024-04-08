using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Controllers
{
    public class SpecieController : Controller
    {
        private readonly ISpecieService specieService;

        public SpecieController(ISpecieService specieService)
        {
            this.specieService = specieService;
        }


        public async Task<IActionResult> All()
        {
            return View(new SpecieFormModel
            {
                AllSpeciesList = await specieService.GetAllSpeciesAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> All(SpecieFormModel modelSpecie)
        {
            if (await specieService.SpecieNameExistsAsync(modelSpecie.NewSpecieName))
            {
                this.ModelState.AddModelError(nameof(Specie.Id), "Specie already exists.");
            }

            if (ModelState.IsValid == false)
            {
                modelSpecie.AllSpeciesList = await specieService.GetAllSpeciesAsync();
                return View(modelSpecie);
            }

            await specieService.AddSpecieAsync(modelSpecie.NewSpecieName);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await specieService.SpecieIdExistsAsync(id) == false)
            {
                return BadRequest();
            }

            await specieService.DeleteSpecieAsync(id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await specieService.SpecieIdExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var currentSpecie = await specieService.GetSpecieByIdAsync(id);
            return View(new SpecieFormModel
            {
                NewSpecieName = currentSpecie.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SpecieFormModel modelSpecie)
        {
            if (ModelState.IsValid == false)
            {
                return View(modelSpecie);
            }

            var currentSpecie = await specieService.GetSpecieByIdAsync(id);
            if (currentSpecie == null)
            {
                return BadRequest();
            }

            await specieService.EditSpecieAsync(currentSpecie, modelSpecie);

            return RedirectToAction("All");
        }
    }
}
