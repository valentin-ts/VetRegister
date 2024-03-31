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

            if (!ModelState.IsValid)
            {
                return View(modelProcedure);
            }

            var doctorId = doctorService.GetDoctorId(userId);

            procedureService.Add(modelProcedure, animalId, doctorId);

            return RedirectToAction("All");
        }
    }
}
