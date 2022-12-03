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
        public IActionResult All()
        {
            //if user is a doctor
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIsDoctor = this.data.Doctors.Any(d => d.UserId == userId);

            return View(new BreedFormModel
                {
                    AllBreedsList = this.GetAnimalBreeds()
                }
            );
        }

        [HttpPost]
        public IActionResult All(BreedFormModel breed)
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

            return RedirectToAction("All", "Breeds");
        }


        public IActionResult Delete(int id)
        {
            var currentBreed = this.data.Breeds.Find(id);

            if (currentBreed == null)
            {
                return BadRequest();
            }

            if (this.data.Animals.Any(a => a.BreedId == id))
            {
                return RedirectToAction("All");
                //return StatusCode(418);
            }

            this.data.Breeds.Remove(currentBreed);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }



        private IEnumerable<BreedViewModel> GetAnimalBreeds()
        {
            return this.data
                .Breeds
                .Select(a => new BreedViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }
    }
}
