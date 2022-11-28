using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id, ExamFormModel model)
        {
            //Animal currentAnimal = this.data.Animals.Include(a => a.Breed).FirstOrDefault(a => a.Id == animalId);
            Animal currentAnimal = this.data.Animals.Find(id);

            Exam currentExam = new Exam
            {
                Animal = currentAnimal,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow
            };

            this.data.Exams.Add(currentExam);
            this.data.SaveChanges();

            return RedirectToAction("Details", "Animals", new { id = id });
        }
    }
}
