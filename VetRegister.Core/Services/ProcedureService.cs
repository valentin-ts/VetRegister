using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly ApplicationDbContext data;

        public ProcedureService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync()
        {
            return await data
                .Procedures
                .Select(p => new ProcedureViewModel
                {
                    Id = p.Id,
                    AnimalName = p.Animal.Name,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn.ToString("d"),
                    DoctorName = p.Doctor.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddProcedureAsync(ProcedureFormModel modelProcedure, int animalId, int doctorId)
        {
            Procedure newProcedure = new Procedure
            {
                Description = modelProcedure.Description,
                CreatedOn = DateTime.Parse(modelProcedure.CreatedOn),
                AnimalId = animalId,
                DoctorId = doctorId
            };

            await data.Procedures.AddAsync(newProcedure);
            await data.SaveChangesAsync();
        }
    }
}
