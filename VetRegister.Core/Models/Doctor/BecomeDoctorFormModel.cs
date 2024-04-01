using System.ComponentModel.DataAnnotations;
using VetRegister.Core.Models.Clinic;

namespace VetRegister.Core.Models.Doctor
{
    public class BecomeDoctorFormModel
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        public int ClinicId { get; set; }

        public IEnumerable<ClinicViewModel> Clinics { get; set; } = new List<ClinicViewModel>();
    }
}
