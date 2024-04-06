using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.MessageConstants;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Core.Models.Procedure
{
    public class ProcedureFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name = "Created On")]
        public string CreatedOn { get; set; } = string.Empty;

    }
}
