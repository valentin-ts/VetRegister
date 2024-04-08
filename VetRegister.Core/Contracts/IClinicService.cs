using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IClinicService
    {
        public Task<bool> ClinicIdExistsAsync(int id);

        public Task<bool> ClinicNameTakenAsync(string name);

        public Task AddClinicAsync(ClinicFormModel modelClinic);

        public Task<Clinic?> GetClinicByIdAsync(int id);

        public Task<Clinic?> GetClinicByIdIncludeDoctorsAsync(int id);

        public Task EditClinicAsync(Clinic currentClinic, ClinicFormModel modelClinic);

        public Task<bool> ClinicHasAnyDoctorsAsync(int id);

        public Task DeleteClinicAsync(Clinic currentClinic);

        public Task<IEnumerable<ClinicViewModel>> GetAllClinicsAsync();

        public Task<IEnumerable<string>> GetDoctorNamesForClinicAsync(int id);
    }
}
