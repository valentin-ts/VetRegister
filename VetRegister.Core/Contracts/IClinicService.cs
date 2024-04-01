using VetRegister.Core.Models.Clinic;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IClinicService
    {
        public bool NameTaken(string name);

        public void Add(ClinicFormModel clinic);

        public Clinic GetById(int id);

        public Clinic GetByIdIncludeDoctors(int id);

        public void Edit(int id, ClinicFormModel modelClinic);

        public bool HasAnyDoctors(int id);

        public void Delete(Clinic currentClinic);

        public IEnumerable<ClinicViewModel> GetAllClinics();

        public IEnumerable<string> GetDoctorsForClinic(int clinicId);
    }
}
