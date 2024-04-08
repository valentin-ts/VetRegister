using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Owner;
using VetRegister.Infrastructure.Data.Models;

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
            return View(ownerService.GetAllOwnersAsync());
        }

        public IActionResult Details(int id)
        {
            return View(ownerService.GetOwnerDetailsAsync(id));
        }

        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeOwnerFormModel owner)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            var newOwner = new Owner
            {
                UserId = userId,
                Address = owner.Address,
                PhoneNumber = owner.PhoneNumber
            };

            ownerService.CreateOwnerAsync(newOwner);

            return RedirectToAction("Index", "Home");
        }
    }
}
