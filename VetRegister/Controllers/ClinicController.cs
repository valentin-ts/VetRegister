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
            if (clinicService.ClinicNameTaken(clinic.Name))
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

        //[Authorize]
        public IActionResult Edit(int id)
        {
            //DO A USERID CHECK !!!!!!!!!!!! if he is authorised
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentClinic = clinicService.GetClinicById(id);

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
            //DO A USERID CHECK !!!!!!!!!!!! if he is authorised
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentClinic = clinicService.GetClinicById(id);
            clinicService.Edit(currentClinic, modelClinic);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var currentClinic = clinicService.GetClinicById(id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            if (clinicService.ClinicHasDoctors(currentClinic.Id))
            {
                return RedirectToAction("All");
                //Cannot Erase, full of doctors
                //return StatusCode(418);
            }

            clinicService.Delete(currentClinic);

            return RedirectToAction("All");
        }

        public IActionResult Details(int id)
        {
            //Is include doctors really needed??? !!!!!!!!!!!!!!
            var currentClinic = clinicService.GetClinicByIdIncludeDoctors(id);

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
            });
        }

        //[Authorize]
        public IActionResult All()
        {
            return View(clinicService.GetAllClinics());
        }
    }
}
