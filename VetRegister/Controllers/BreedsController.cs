using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VetRegister.Data;
using VetRegister.Data.Models;
using VetRegister.Models.Breeds;

namespace VetRegister.Controllers
{
    public class BreedsController : Controller
    {
        private readonly VetRegisterDbContext data;
        
        public BreedsController(VetRegisterDbContext data)
        {
            this.data = data;
        }

        //[Authorize]
        public IActionResult ViewAll()
        {
            //if user is a doctor
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIsDoctor = this.data.Doctors.Any(d => d.UserId == userId);

            return View(new AllBreedsViewModel
                {
                    AllBreedsList = this.GetAnimalBreeds()
                }
            );
        }

        [HttpPost]
        public IActionResult ViewAll(AllBreedsViewModel breed)
        {
            //if breed exists
            if (this.data.Breeds.Any(b => b.Name == breed.NewBreedName))
            {
                return RedirectToAction("Exists", "Breeds");  //Make a controller for this
            }

            var newBreed = new Breed
            {
                Name = breed.NewBreedName,
            };
            data.Breeds.Add(newBreed);
            data.SaveChanges();

            return RedirectToAction("ViewAll", "Breeds");
        }

        private IEnumerable<SingleBreedViewModel> GetAnimalBreeds()
        {
            return this.data
                .Breeds
                .Select(a => new SingleBreedViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }
    }
}
