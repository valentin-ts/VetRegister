using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Procedure;

namespace VetRegister.Controllers
{
    public class ProcedureController : Controller
    {
        private readonly IProcedureService procedureService;
        private readonly IDoctorService doctorService;

        public ProcedureController(IProcedureService procedureService, IDoctorService doctorService)
        {
            this.procedureService = procedureService;
            this.doctorService = doctorService;

        }
        public IActionResult All()
        {
            return View(procedureService.GetAllProcedures());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProcedureFormModel modelProcedure, int animalId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest();
            }

            var doctorId = doctorService.GetDoctorId(userId);
            if (doctorId == null) 
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(modelProcedure);
            }

            procedureService.Add(modelProcedure, animalId, (int)doctorId); // casting to int as it is already checked that it is not null

            return RedirectToAction("All");
        }
    }
}
