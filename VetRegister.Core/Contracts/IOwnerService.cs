using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Models.Doctor;
using VetRegister.Core.Models.Owner;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IOwnerService
    {
        public int? GetOwnerId(string? userId);

        public IEnumerable<OwnerViewModel> GetAllOwners();

        public OwnerDetailsViewModel GetOwnerDetails(int id);

        public void CreateOwner(Owner newOwner);
    }
}
