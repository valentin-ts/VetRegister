using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Animal;
using VetRegister.Core.Models.Owner;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext data;

        public OwnerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<OwnerViewModel> GetAllOwners()
        {
            return this.data
            .Owners
            .Include(o => o.User)
            .Include(o => o.Animals)
            .Select(o => new OwnerViewModel
            {
                Id = o.Id,
                Name = o.User.UserName,
                AnimalsCount = o.Animals.Count()
            })
            .ToList();
        }

        public OwnerDetailsViewModel GetOwnerDetails(int id)
        {
            var animals = this.data
            .Animals
            .Include(a => a.Specie)
            .Where(a => a.Owner.Id == id)
            .Select(a => new AnimalViewModel
            {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth.ToString("d"),
                SpecieName = a.Specie.Name
            })
            .ToList();

            return new OwnerDetailsViewModel
            {
                Id = id,
                Name = "test",
                Animals = animals
            };
        }

        public int? GetOwnerId(string? userId)
        {
            return this.data.Owners.FirstOrDefault(o => o.UserId == userId)?.Id;
        }

        public void CreateOwner(Owner newOwner)
        {
            this.data.Owners.Add(newOwner);
            this.data.SaveChanges();
        }
    }
}
