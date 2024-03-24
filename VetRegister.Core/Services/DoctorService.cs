using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Contracts;
using VetRegister.Infrastructure.Data;

namespace VetRegister.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext data;

        public DoctorService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int GetDoctorId(string userId)
        {
            return data.Doctors.FirstOrDefault(o => o.UserId == userId).Id;
        }
    }
}
