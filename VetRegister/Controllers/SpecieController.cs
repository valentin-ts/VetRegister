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


        public IActionResult All()
        {
            return View(new SpecieFormModel
            {
                AllSpeciesList = specieService.GetAll()
            });
        }

        [HttpPost]
        public IActionResult All(SpecieFormModel modelSpecie)
        {
            if (specieService.NameExists(modelSpecie.NewSpecieName))
            {
                this.ModelState.AddModelError(nameof(Specie.Id), "Specie already exists.");
            }

            if (!ModelState.IsValid)
            {
                modelSpecie.AllSpeciesList = specieService.GetAll();
                return View(modelSpecie);
            }

            specieService.Add(modelSpecie.NewSpecieName);

            return RedirectToAction("All");
        }


        public IActionResult Delete(int id)
        {
            if (!specieService.IdExists(id))
            {
                return BadRequest();
            }

            specieService.Delete(id);

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            if (!specieService.IdExists(id))
            {
                return BadRequest();
            }

            var currentSpecie = specieService.FindById(id);
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
