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
        public Task<int?> GetOwnerIdAsync(string? userId);

        public Task<IEnumerable<OwnerViewModel>> GetAllOwnersAsync();

        public Task<OwnerViewModel> GetOwnerDetailsAsync(int id);

        public Task CreateOwnerAsync(Owner newOwner);
    }
}
