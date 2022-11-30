using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Clinics;
using VetRegister.Models.Persons;

namespace VetRegister.Controllers
{
    public class PersonsController : Controller
    {
        private readonly VetRegisterDbContext data;

        public PersonsController(VetRegisterDbContext data)
        {
            this.data = data;
        }

        public IActionResult BecomeDoctor()
        {
            return View(new BecomeDoctorFormModel
            {
                Clinics = GetAllClinics()
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult BecomeDoctor(BecomeDoctorFormModel doctor)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var userIdsAlreadyDoctor (or an owner??)= this.data
            //    .Doctors
            //    .Any(d => d.PersonId == userId); ???

            //if (userIdsAlreadyDoctor)
            //{
            //    return BadRequest();
            //}

            //check if ClinicId exists in database
            if (!this.data.Clinics.Any(c => c.Id == doctor.ClinicId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                doctor.Clinics = GetAllClinics();
                return View(doctor);
            }

            var newDoctor = new Doctor
            {
                FullName = doctor.FullName,
                PersonId = userId,
                ClinicId = doctor.ClinicId
            };

            this.data.Doctors.Add(newDoctor);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ClinicViewModel> GetAllClinics()
        {
            return this.data
                .Clinics
                .Select(c => new ClinicViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                })
                .ToList();
        }
    }
}
