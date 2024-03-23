using System.ComponentModel.DataAnnotations;

namespace VetRegister.Core.Models.Clinic
{
    public class ClinicFormModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
