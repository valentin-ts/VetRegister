using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data.Models;
using VetRegister.Models.Clinics;

namespace VetRegister.Models.Persons
{
    public class BecomeOwnerFormModel
    {
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public IEnumerable<Animal> Pets { get; set; } = new List<Animal>();
    }
}
