using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data;

namespace VetRegister.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly VetRegisterDbContext data;

        public PersonService(VetRegisterDbContext data)
            => this.data = data;

        public bool IsDoctor(string userId)
            => this.data
                .Doctors
                .Any(d => d.PersonId == userId);

        public bool IsOwner(string userId)
            => this.data
            .Owners
            .Any(d => d.PersonId == userId);
    }
}
