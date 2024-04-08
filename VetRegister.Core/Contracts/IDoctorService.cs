using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Models.Doctor;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IDoctorService
    {
        public Task<bool> DoctorExistsAsync(int id);

        public Task<int?> GetDoctorIdAsync(string? userId);

        public Task<DoctorViewModel?> GetDoctorByIdAsync(int id);

        public Task<IEnumerable<DoctorViewModel>> GetAllDoctorsAsync();

        public Task<DoctorViewModel> GetDoctorDetailsAsync(int id);

        public Task CreateDoctorAsync(Doctor newDoctor);
    }
}
