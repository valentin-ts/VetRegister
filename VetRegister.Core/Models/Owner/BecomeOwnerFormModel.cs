using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.MessageConstants;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Core.Models.Owner
{
    public class BecomeOwnerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
