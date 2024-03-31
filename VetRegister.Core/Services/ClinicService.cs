using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;


using System.Collections.Generic;
using System.Linq;



namespace VetRegister.Core.Services
{
    public class ClinicService : IClinicService
    {
        private readonly ApplicationDbContext data;

        public ClinicService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(ClinicFormModel clinic)
        {
            var newClinic = new Clinic
            {
                Name = clinic.Name,
                PhoneNumber = clinic.PhoneNumber
            };

            data.Clinics.Add(newClinic);
            data.SaveChanges();
        }

        public bool HasAnyDoctors(int id)
        {
            return this.data.Doctors.Any(d => d.ClinicId == id);
        }

        public bool NameTaken(string name)
        {
            return this.data.Clinics.Any(c => c.Name == name);
        }

        public void Delete(Clinic currentClinic)
        {
            this.data.Clinics.Remove(currentClinic);
            this.data.SaveChanges();
        }

        public void Edit(int id, ClinicFormModel modelClinic)
        {
            var currentClinic = GetById(id);
            currentClinic.Name = modelClinic.Name;
            currentClinic.PhoneNumber = modelClinic.PhoneNumber;

            data.SaveChanges();
        }

        public IEnumerable<ClinicViewModel> GetAllClinics()
        {
            return this.data
            .Clinics
            .Select(c => new ClinicViewModel
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
            })
            .ToList();
        }

        public Clinic GetById(int id)
        {
            return this.data.Clinics.Find(id);
        }

        public Clinic GetByIdIncludeDoctors(int id)
        {
            return this.data
                .Clinics
                .Include(c => c.Doctors)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<string> GetDoctorsForClinic(int clinicId)
        {
            return this.data
                .Doctors
                .Where(d => d.ClinicId == clinicId)
                .Select(d => d.Name)
                .ToList();
        }
    }
}
