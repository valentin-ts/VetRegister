using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Models.Doctor;
using VetRegister.Core.Models.Procedure;

namespace VetRegister.Core.Contracts
{
    public interface IDoctorService
    {
        public int GetDoctorId(string userId);

        public DoctorViewModel GetById(int id);

        public IEnumerable<DoctorViewModel> GetAllDoctors();

        public DoctorDetailsViewModel GetDoctorDetails(int id);
    }
}
