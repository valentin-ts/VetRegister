using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Specie;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class SpecieService : ISpecieService
    {
        private readonly ApplicationDbContext data;

        public SpecieService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> SpecieIdExistsAsync(int specieId)
        {
            return await data
                .Species
                .AsNoTracking()
                .AnyAsync(b => b.Id == specieId);
        }

        public async Task<bool> SpecieNameExistsAsync(string specieName)
        {
            return await data
                .Species
                .AsNoTracking()
                .AnyAsync(b => b.Name == specieName);
        }

        public async Task<string> GetSpecieNameAsync(int specieId)
        {
            return (await data
                .Species
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id ==specieId))!
                .Name;
        }

        public async Task<IEnumerable<SpecieViewModel>> GetAllSpeciesAsync()
        {
            return await data
                .Species
                .Select(a => new SpecieViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddSpecieAsync(string newSpecieName)
        {
            var newSpecie = new Specie
            {
                Name = newSpecieName
            };

            await data.Species.AddAsync(newSpecie);
            await data.SaveChangesAsync();
        }

        public async Task DeleteSpecieAsync(int id)
        {
            Specie currentSpecie = (await data.Species.FirstOrDefaultAsync(s => s.Id == id))!;
            data.Species.Remove(currentSpecie);
            await data.SaveChangesAsync();
        }

        public async Task EditSpecieAsync(Specie currentSpecie, SpecieFormModel modelSpecie)
        {
            currentSpecie.Name = modelSpecie.NewSpecieName;
            await data.SaveChangesAsync();
        }

        public async Task<Specie> GetSpecieByIdAsync(int id)
        {
            return (await data
                .Species
                .FirstOrDefaultAsync(s => s.Id == id))!;
        }
    }
}
