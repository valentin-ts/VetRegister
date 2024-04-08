using Microsoft.EntityFrameworkCore;
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

        public bool DoctorExists(int id)
        {
            return this.data
                .Doctors
                .Any(d => d.Id == id);
        }

        public IEnumerable<DoctorViewModel> GetAllDoctors()
        {
            return this.data
                .Doctors
                .Include(d => d.Clinic)
                .Select(d => new DoctorViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ClinicName = d.Clinic.Name,
                    ProceduresCount = d.Procedures.Count()
                })
                .ToList();
        }

        public DoctorViewModel GetDoctorDetails(int id)
        {
            var procedures = this.data
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
            .ToList();

            return new DoctorViewModel
            {
                Id = id,
                Name = this.data.Doctors.Find(id)!.Name,
                ClinicName = this.data.Doctors.Include(d => d.Clinic).FirstOrDefault(d => d.Id == id)!.Clinic.Name,
                Procedures = procedures
            };
        }


        public DoctorViewModel? GetById(int id)
        {
            return this.data
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
                }).FirstOrDefault();
        }

        public int? GetDoctorId(string? userId)
        {
            return this.data.Doctors.FirstOrDefault(d => d.UserId == userId)?.Id;
        }

        public void CreateDoctor(Doctor newDoctor)
        {
            this.data.Doctors.Add(newDoctor);
            this.data.SaveChanges();
        }


    }
}
