using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Clinic;
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

        public IEnumerable<ProcedureViewModel> GetAllProcedures()
        {
            return this.data
                .Procedures
                .Select(p => new ProcedureViewModel
                {
                    Id = p.Id,
                    AnimalName = p.Animal.Name,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn.ToString("d"),
                    DoctorName = p.Doctor.Name
                })
            .ToList();
        }

        public void Add(ProcedureFormModel modelProcedure, int animalId, int doctorId)
        {
            Procedure newProcedure = new Procedure
            {
                Description = modelProcedure.Description,
                CreatedOn = DateTime.Parse(modelProcedure.CreatedOn),
                AnimalId = animalId,
                DoctorId = doctorId
            };

            data.Procedures.Add(newProcedure);
            data.SaveChanges();
        }
    }
}
