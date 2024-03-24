using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IClinicService
    {
        public bool ClinicNameTaken(string name);

        public void Add(ClinicFormModel clinic);

        public Clinic GetClinicById(int id);

        public Clinic GetClinicByIdIncludeDoctors(int id);

        public void Edit(int id, ClinicFormModel modelClinic);

        public bool ClinicHasDoctors(int id);

        public void Delete(Clinic currentClinic);
        public IEnumerable<ClinicViewModel> GetAllClinics();

        public IEnumerable<string> GetDoctorsForClinic(int clinicId);
    }
}
