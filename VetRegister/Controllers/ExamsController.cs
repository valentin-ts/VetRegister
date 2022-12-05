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
using VetRegister.Models.Exams;
using VetRegister.Services.Persons;

namespace VetRegister.Controllers
{
    [Authorize]
    public class ExamsController : Controller
    {
        private readonly VetRegisterDbContext data;
        private readonly IPersonService person;

        public ExamsController(VetRegisterDbContext data, IPersonService person)
        {
            this.data = data;
            this.person = person;
        }

        public IActionResult Add(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }

            return View(new ExamFormModel
            {
                Procedures = this.GetExamProcedures()
            });
        }

        [HttpPost]
        public IActionResult Add(int id, ExamFormModel modelExam)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                modelExam.Procedures = this.GetExamProcedures();
                return View(modelExam);
            }

            Animal currentAnimal = this.data.Animals.Find(id);
            var currentDoctor = data.Doctors.FirstOrDefault(d => d.PersonId == userId);

            Exam newExam = new Exam
            {
                Description = modelExam.Description,
                CreatedOn = DateTime.UtcNow,
                Animal = currentAnimal,
                DoctorId = currentDoctor.Id,
                ProcedureId = modelExam.ProcedureId
            };

            this.data.Exams.Add(newExam);
            this.data.SaveChanges();

            return RedirectToAction("All", "Exams", new { id });
        }

        public IActionResult All()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }

            return View(GetAllExamsForDoctor(userId));
        }


        public IActionResult Details(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }
            var doctorId = data.Doctors.FirstOrDefault(d => d.PersonId == userId).Id;

            //var currentExam = this.data.Exams.Find(id);
            var currentExam = this.data.Exams.Include(e => e.Animal).Include(e => e.Doctor).Include(e => e.Procedure).FirstOrDefault(e => e.Id == id);
            if (currentExam == null)
            {
                return BadRequest();
            }

            if (currentExam.DoctorId != doctorId)
            {
                return BadRequest();
            }

            return View(new ExamViewModel
            {
                Id = currentExam.Id,
                Description = currentExam.Description,
                CreatedOn = currentExam.CreatedOn.ToString("d"),
                AnimalName = currentExam.Animal.Name,
                DoctorName = currentExam.Doctor.FullName,
                ProcedureName = currentExam.Procedure.Name
            });
        }

        public IActionResult Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }
            var doctorId = data.Doctors.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentExam = this.data.Exams.Find(id);
            if (currentExam == null)
            {
                return BadRequest();
            }

            if (currentExam.DoctorId != doctorId)
            {
                return BadRequest();
            }

            this.data.Exams.Remove(currentExam);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }



        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }
            var doctorId = data.Doctors.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentExam = this.data.Exams.Find(id);
            if (currentExam == null)
            {
                return BadRequest();
            }

            if (currentExam.DoctorId != doctorId)
            {
                return BadRequest();
            }

            return View(new ExamFormModel
            {
                Description = currentExam.Description,
                ProcedureId = currentExam.ProcedureId,
                Procedures = this.GetExamProcedures()
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, ExamFormModel modelExam)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!person.IsDoctor(userId))
            {
                return BadRequest();
            }
            var doctorId = data.Doctors.FirstOrDefault(d => d.PersonId == userId).Id;

            var currentExam = this.data.Exams.Find(id);
            if (currentExam == null)
            {
                return BadRequest();
            }

            if (currentExam.DoctorId != doctorId)
            {
                return BadRequest();
            }

            currentExam.Description = modelExam.Description;
            currentExam.ProcedureId = modelExam.ProcedureId;

            this.data.SaveChanges();

            return RedirectToAction("All");
        }

        private IEnumerable<ExamProcedureViewModel> GetExamProcedures()
        {
            return this.data
                .Procedures
                .Select(a => new ExamProcedureViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }

        private IEnumerable<ExamViewModel> GetAllExamsForDoctor(string doctorId)
        {
            return this.data
                .Exams
                .Where(e => e.Doctor.PersonId == doctorId)
                .Select(e => new ExamViewModel
                {
                    Id = e.Id,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("d"),
                    AnimalName = e.Animal.Name,
                    DoctorName = e.Doctor.FullName,
                    ProcedureName = e.Procedure.Name
                })
                .ToList();
        }
    }
}
