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

namespace VetRegister.Controllers
{
    public class ExamsController : Controller
    {
        private readonly VetRegisterDbContext data;

        public ExamsController(VetRegisterDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add(int id)
        {
            return View(new ExamFormModel
            {
                Procedures = this.GetExamProcedures()
            });
        }

        [HttpPost]
        public IActionResult Add(int id, ExamFormModel modelExam)
        {
            if (!ModelState.IsValid)
            {
                modelExam.Procedures = this.GetExamProcedures();
                return View(modelExam);
            }

            Animal currentAnimal = this.data.Animals.Find(id);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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

            return RedirectToAction("All", "Exams", new { id = id });
        }

        public IActionResult All()
        {
            return View(GetAllExams());
        }


        public IActionResult Details(int id)
        {
            //var currentExam = this.data.Exams.Find(id);
            var currentExam = this.data.Exams.Include(e => e.Animal).Include(e => e.Doctor).Include(e => e.Procedure).FirstOrDefault(e => e.Id == id);

            if (currentExam == null)
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
            //check for exams etc...
            var currentExam = this.data.Exams.Find(id);

            if (currentExam == null)
            {
                return BadRequest();
            }

            this.data.Exams.Remove(currentExam);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }



        public IActionResult Edit(int id)
        {
            //check if owner is correct
            var currentExam = this.data.Exams.Find(id);

            if (currentExam == null)
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
            //check if owner is correct
            var currentExam = this.data.Exams.Find(id);

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

        private IEnumerable<ExamViewModel> GetAllExams()
        {
            return this.data
                .Exams
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
