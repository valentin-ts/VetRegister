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

        public IActionResult All()
        {
            return View(doctorService.GetAllDoctors());
        }

        public IActionResult Details(int id) 
        {
            if (!doctorService.DoctorExists(id))
            {
                return BadRequest();
            }

            return View(doctorService.GetDoctorDetails(id));
        }

        public IActionResult Become()
        {
            return View(new BecomeDoctorFormModel
            {
                Clinics = clinicService.GetAllClinics()
            });
        }

        [HttpPost]
        public IActionResult Become(BecomeDoctorFormModel doctor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                doctor.Clinics = clinicService.GetAllClinics();
                return View(doctor);
            }

            var newDoctor = new Doctor
            {
                Name = doctor.Name,
                UserId = userId,
                ClinicId = doctor.ClinicId,
            };

            doctorService.CreateDoctor(newDoctor);

            return RedirectToAction("Index", "Home");
        }

    }
}
