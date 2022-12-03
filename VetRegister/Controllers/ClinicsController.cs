using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Clinics;
using VetRegister.Models.Persons;

namespace VetRegister.Areas.Clinics.Controllers
{
    public class ClinicsController : Controller
    {
        private readonly VetRegisterDbContext data;

        public ClinicsController(VetRegisterDbContext data)
        {
            this.data = data;
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
            if (this.data.Clinics.Any(c => c.Name == clinic.Name))
            {
                ViewBag.ClinicNameExists = true;
                return View(clinic);
            }

            if (!ModelState.IsValid)
            {
                return View(clinic);
            }

            var newClinic = new Clinic
            {
                Name = clinic.Name,
                PhoneNumber = clinic.PhoneNumber
            };

            data.Clinics.Add(newClinic);
            data.SaveChanges();

            return RedirectToAction("All");
        }

        //[Authorize]
        public IActionResult Edit(int id)
        {
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var clinic = this.data
                .Clinics
                .Where(c => c.Id == id)
                .Select(c => new ClinicFormModel
                {
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber
                })
                .FirstOrDefault();

            return View(clinic);
        }

        [HttpPost]
        public IActionResult Edit(int id, ClinicFormModel clinic)
        {
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentClinic = this.data.Clinics.Find(id);

            currentClinic.Name = clinic.Name;
            currentClinic.PhoneNumber = clinic.PhoneNumber;

            data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var currentClinic = this.data.Clinics.Find(id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            if (this.data.Doctors.Any(d => d.ClinicId == id))
            {
                return RedirectToAction("All");
                //return StatusCode(418);
            }

            this.data.Clinics.Remove(currentClinic);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult Details(int id)
        {
            //var currentClinic = this.data.Clinics.Find(id);
            var currentClinic = this.data
                .Clinics
                .Include(c => c.Doctors)
                .FirstOrDefault(c => c.Id == id);

            if (currentClinic == null)
            {
                return BadRequest();
            }

            return View(new ClinicViewModel
            {
                Id = currentClinic.Id,
                Name = currentClinic.Name,
                PhoneNumber = currentClinic.PhoneNumber,
                Doctors = GetDoctorsForClinic(id)
            });
        }

        //[Authorize]
        public IActionResult All()
        {
            return View(GetAllClinics());
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

        private IEnumerable<string> GetDoctorsForClinic(int clinicId)
        {
            return this.data
                .Doctors
                .Where(d => d.ClinicId == clinicId)
                .Select(d => d.FullName)
                .ToList();
        }
    }
}
