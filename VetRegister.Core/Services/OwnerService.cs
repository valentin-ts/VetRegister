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

        public async Task<IEnumerable<OwnerViewModel>> GetAllOwnersAsync()
        {
            return await data
            .Owners
            .Include(o => o.User)
            .Include(o => o.Animals)
            .Select(o => new OwnerViewModel
            {
                Id = o.Id,
                Name = o.User.UserName,
                AnimalsCount = o.Animals.Count()
            })
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<OwnerViewModel> GetOwnerDetailsAsync(int id)
        {
            var animals = await data
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
            .AsNoTracking()
            .ToListAsync();

            return new OwnerViewModel
            {
                Id = id,
                Name = "test",
                Animals = animals
            };
        }

        public async Task<int?> GetOwnerIdAsync(string? userId)
        {
            return (await data
                .Owners
                .FirstOrDefaultAsync(o => o.UserId == userId))?.Id;
        }

        public async Task CreateOwnerAsync(Owner newOwner)
        {
            await data.Owners.AddAsync(newOwner);
            await data.SaveChangesAsync();
        }
    }
}
