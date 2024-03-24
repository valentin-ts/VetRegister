using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Contracts;
using VetRegister.Infrastructure.Data;

namespace VetRegister.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext data;

        public OwnerService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int GetOwnerId(string userId)
        {
            return data.Owners.FirstOrDefault(o => o.UserId == userId).Id;
        }
    }
}
