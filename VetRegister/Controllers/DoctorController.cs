using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;

namespace VetRegister.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;
        private readonly IProcedureService procedureService;

        public DoctorController(IDoctorService doctorService, IProcedureService procedureService)
        {
            this.doctorService = doctorService;
            this.procedureService = procedureService;
        }

        public IActionResult All()
        {
            return View(doctorService.GetAllDoctors());
        }

        public IActionResult Details(int id) 
        {
            return View(doctorService.GetDoctorDetails(id));
        }
    }
}
