using Microsoft.AspNetCore.Mvc;
using VetRegister.Core.Contracts;
using VetRegister.Core.Services;

namespace VetRegister.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
                this.ownerService = ownerService;
        }

        public IActionResult All()
        {
            return View(ownerService.GetAllOwners());
        }

        public IActionResult Details(int id)
        {
            return View(ownerService.GetOwnerDetails(id));
        }
    }
}
