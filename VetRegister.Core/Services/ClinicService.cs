using Microsoft.EntityFrameworkCore;
using VetRegister.Core.Contracts;
using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data;
using VetRegister.Infrastructure.Data.Models;



namespace VetRegister.Core.Services
{
    public class ClinicService : IClinicService
    {
        private readonly ApplicationDbContext data;

        public ClinicService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<bool> ClinicIdExistsAsync(int clinicId)
        {
            return await data
                .Clinics
                .AnyAsync(c => c.Id == clinicId);
        }

        public async Task AddClinicAsync(ClinicFormModel clinic)
        {
            var newClinic = new Clinic
            {
                Name = clinic.Name,
                PhoneNumber = clinic.PhoneNumber
            };

            await data.Clinics.AddAsync(newClinic);
            await data.SaveChangesAsync();
        }


        public async Task<bool> ClinicHasAnyDoctorsAsync(int id)
        {
            return await data
                .Doctors
                .AnyAsync(d => d.ClinicId == id);
        }

        public async Task<bool> ClinicNameTakenAsync(string name)
        {
            return await data
                .Clinics
                .AnyAsync(c => c.Name == name);
        }

        public async Task DeleteClinicAsync(int id)
        {
            var currentClinic = await GetClinicByIdAsync(id);
            data.Clinics.Remove(currentClinic!);
            await data.SaveChangesAsync();
        }

        public async Task EditClinicAsync(int id, ClinicFormModel modelClinic)
        {
            var currentClinic = await GetClinicByIdAsync(id);

            currentClinic!.Name = modelClinic.Name;
            currentClinic!.PhoneNumber = modelClinic.PhoneNumber;
            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClinicViewModel>> GetAllClinicsAsync()
        {
            return await data
            .Clinics
            .Select(c => new ClinicViewModel
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
            })
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Clinic?> GetClinicByIdAsync(int id)
        {
            return await data
                .Clinics
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Clinic?> GetClinicByIdIncludeDoctorsAsync(int id)
        {
            return await data
                .Clinics
                .Include(c => c.Doctors)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<string>> GetDoctorNamesForClinicAsync(int clinicId)
        {
            return await data
                .Doctors
                .Where(d => d.ClinicId == clinicId)
                .Select(d => d.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
