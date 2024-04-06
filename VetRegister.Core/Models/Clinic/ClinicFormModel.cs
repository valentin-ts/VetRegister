using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.MessageConstants;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Core.Models.Clinic
{
    public class ClinicFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
