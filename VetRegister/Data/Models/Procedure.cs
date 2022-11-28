using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
