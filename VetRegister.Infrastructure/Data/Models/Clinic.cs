using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Clinic
    {
        [Comment("Clinic Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClinicNameMaxLenght)]
        [Comment("Clinic Name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Clinic Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
