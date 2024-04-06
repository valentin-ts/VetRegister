using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.MessageConstants;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Core.Models.Specie
{
    public class SpecieFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string NewSpecieName { get; set; } = string.Empty;

        public IEnumerable<SpecieViewModel> AllSpeciesList { get; set; } = new List<SpecieViewModel>();
    }
}
