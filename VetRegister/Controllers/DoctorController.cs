using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Doctor;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly IProcedureService procedureService;
        private readonly IClinicService clinicService;

        public DoctorController(IDoctorService doctorService, IProcedureService procedureService, IClinicService clinicService)
        {
            this.doctorService = doctorService;
            this.procedureService = procedureService;
            this.clinicService = clinicService;
        }

        public async Task<IActionResult> All()
        {
            return View(await doctorService.GetAllDoctorsAsync());
        }

        public async Task<IActionResult> Details(int id) 
        {
            if (await doctorService.DoctorExistsAsync(id) == false)
            {
                return BadRequest();
            }

            return View(await doctorService.GetDoctorDetailsAsync(id));
        }

        public async Task<IActionResult> Become()
        {
            return View(new BecomeDoctorFormModel
            {
                Clinics = await clinicService.GetAllClinicsAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDoctorFormModel doctor)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                doctor.Clinics = await clinicService.GetAllClinicsAsync();
                return View(doctor);
            }

            var newDoctor = new Doctor
            {
                Name = doctor.Name,
                UserId = userId,
                ClinicId = doctor.ClinicId,
            };

            await doctorService.CreateDoctorAsync(newDoctor);

            return RedirectToAction("Index", "Home");
        }

    }
}
