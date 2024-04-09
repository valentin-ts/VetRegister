using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data.Models;

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
        public async Task<IActionResult> Add(ClinicFormModel modelClinic)
        {
            ViewBag.ClinicNameExists = false;
            if ((await clinicService.ClinicNameTakenAsync(modelClinic.Name)) == true)
            {
                ViewBag.ClinicNameExists = true;
                return View(modelClinic);
            }

            if (ModelState.IsValid == false)
            {
                return View(modelClinic);
            }

            await clinicService.AddClinicAsync(modelClinic);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (await clinicService.ClinicIdExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var currentClinic = await clinicService.GetClinicByIdAsync(id);

            var modelClinic = new ClinicFormModel
            {
                Name = currentClinic!.Name,
                PhoneNumber = currentClinic!.PhoneNumber
            };

            return View(modelClinic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClinicFormModel modelClinic)
        {
            
            if (await clinicService.ClinicIdExistsAsync(id) == false)
            {
                return BadRequest();
            }

            await clinicService.EditClinicAsync(id, modelClinic);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await clinicService.ClinicIdExistsAsync(id) == false)
            {
                return BadRequest();
            }

           if (await clinicService.ClinicHasAnyDoctorsAsync(id) == true)
            {
                return BadRequest(); //clinic has doctors
            }

            await clinicService.DeleteClinicAsync(id);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            //var currentClinic = clinicService.GetByIdIncludeDoctors(id);
            var currentClinic = await clinicService.GetClinicByIdAsync(id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            return View(new ClinicViewModel
            {
                Id = currentClinic.Id,
                Name = currentClinic.Name,
                PhoneNumber = currentClinic.PhoneNumber,
                DoctorNames = await clinicService.GetDoctorNamesForClinicAsync(id)
                //Doctors = currentClinic.Doctors.Select(x =>  x.Name).ToList()
            });;
        }

        public async Task<IActionResult> All()
        {
            return View(await clinicService.GetAllClinicsAsync());
        }
    }
}
