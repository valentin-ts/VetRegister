using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Clinic;

namespace VetRegister.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IClinicService clinicService;

        public ClinicController(IClinicService clinicService)
        {
            this.clinicService = clinicService;
        }

        public IActionResult Add()
        {
            ViewBag.ClinicNameExists = false;
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClinicFormModel clinic)
        {
            ViewBag.ClinicNameExists = false;
            if (clinicService.NameTaken(clinic.Name))
            {
                ViewBag.ClinicNameExists = true;
                return View(clinic);
            }

            if (!ModelState.IsValid)
            {
                return View(clinic);
            }

            clinicService.Add(clinic);

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var currentClinic = clinicService.GetById(id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            var modelClinic = new ClinicFormModel
            {
                Name = currentClinic.Name,
                PhoneNumber = currentClinic.PhoneNumber
            };

            return View(modelClinic);
        }

        [HttpPost]
        public IActionResult Edit(int id, ClinicFormModel modelClinic)
        {
            clinicService.Edit(id, modelClinic);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var currentClinic = clinicService.GetById(id);
            
            if (currentClinic == null)
            {
                return BadRequest();
            }

            if (clinicService.HasAnyDoctors(currentClinic.Id))
            {
                return BadRequest();
            }

            clinicService.Delete(currentClinic);

            return RedirectToAction("All");
        }

        public IActionResult Details(int id)
        {
            //var currentClinic = clinicService.GetByIdIncludeDoctors(id);
            var currentClinic = clinicService.GetById(id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            return View(new ClinicViewModel
            {
                Id = currentClinic.Id,
                Name = currentClinic.Name,
                PhoneNumber = currentClinic.PhoneNumber,
                Doctors = clinicService.GetDoctorsForClinic(id)
                //Doctors = currentClinic.Doctors.Select(x =>  x.Name).ToList()
            });;
        }

        public IActionResult All()
        {
            return View(clinicService.GetAllClinics());
        }
    }
}
