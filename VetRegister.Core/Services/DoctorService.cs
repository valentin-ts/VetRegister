using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Doctor;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext data;

        public DoctorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> DoctorExistsAsync(int id)
        {
            return await data
                .Doctors
                .AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DoctorViewModel>> GetAllDoctorsAsync()
        {
            return await data
                .Doctors
                .Include(d => d.Clinic)
                .Select(d => new DoctorViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ClinicName = d.Clinic.Name,
                    ProceduresCount = d.Procedures.Count()
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DoctorViewModel> GetDoctorDetailsAsync(int id)
        {
            var procedures = await data
                .Procedures
                .Where(p => p.Doctor.Id == id)
                .Select(p => new ProcedureViewModel
                {
                    Id = p.Id,
                    AnimalName = p.Animal.Name,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn.ToString("d"),
                    //DoctorName = p.Doctor.Name
                })
                .AsNoTracking()
                .ToListAsync();

            var name = (await data
                .Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id))!
                .Name;

            var clinicName = (await data
                .Doctors
                .Include(d => d.Clinic)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id))!
                .Clinic
                .Name;



            return new DoctorViewModel
            {
                Id = id,
                Name = name,
                ClinicName = clinicName,
                Procedures = procedures
            };
        }


        public async Task<DoctorViewModel?> GetDoctorByIdAsync(int id)
        {
            return await data
                .Doctors
                .Include(d => d.Procedures)
                .Where(d => d.Id == id)
                .Select(d => new DoctorViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ClinicName = d.Clinic.Name,
                    ProceduresCount = d.Procedures.Count(),
                    //Procedures = d.Procedures.Select( p => p.Description)
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int?> GetDoctorIdAsync(string? userId)
        {
            return (await data
                .Doctors
                .FirstOrDefaultAsync(d => d.UserId == userId))?.Id;
        }

        public async Task CreateDoctorAsync(Doctor newDoctor)
        {
            await data.Doctors.AddAsync(newDoctor);
            await data.SaveChangesAsync();
        }


    }
}
