using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Services.Persons
{
    public interface IPersonService
    {
        public bool IsDoctor(string userId);

        public bool IsOwner(string userId);
    }
}
