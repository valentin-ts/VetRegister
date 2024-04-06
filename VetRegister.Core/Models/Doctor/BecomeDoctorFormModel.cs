using System.ComponentModel.DataAnnotations;
using VetRegister.Core.Models.Clinic;
using static VetRegister.Infrastructure.Constants.MessageConstants;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Core.Models.Doctor
{
    public class BecomeDoctorFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Doctor Full Name")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public int ClinicId { get; set; }

        public IEnumerable<ClinicViewModel> Clinics { get; set; } = new List<ClinicViewModel>();
    }
}
