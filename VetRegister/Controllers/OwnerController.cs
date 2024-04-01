using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VetRegister.Core.Contracts;
using VetRegister.Core.Services;
using VetRegister.Infrastructure.Data.Models;
using VetRegister.Core.Models.Owner;

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

        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeOwnerFormModel owner)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

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

            ownerService.CreateOwner(newOwner);

            return RedirectToAction("Index", "Home");
        }
    }
}
