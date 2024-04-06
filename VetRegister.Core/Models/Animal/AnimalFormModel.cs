using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.DataConstants;
using static VetRegister.Infrastructure.Constants.MessageConstants;

namespace VetRegister.Core.Models.Animal
{
    public class AnimalFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]

        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Date Of Birth")]
        public string DateOfBirth{ get; init; } = string.Empty;

        [Required]
        public int SpecieId { get; set; }

        public IEnumerable<AnimalSpecieViewModel> Species { get; set; } = new List<AnimalSpecieViewModel>();
    }
}
