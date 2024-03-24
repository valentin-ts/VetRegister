using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetRegister.Core.Contracts
{
    public interface IDoctorService
    {
        public int GetDoctorId(string userId);
    }
}
