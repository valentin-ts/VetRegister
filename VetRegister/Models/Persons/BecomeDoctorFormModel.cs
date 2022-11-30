using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Models.Clinics;

namespace VetRegister.Models.Persons
{
    public class BecomeDoctorFormModel
    {
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }

        public int ClinicId { get; set; }

        public IEnumerable<ClinicViewModel> Clinics { get; set; }
    }
}
