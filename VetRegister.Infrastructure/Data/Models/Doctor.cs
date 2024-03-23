using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Doctor
    {
        [Key]
        [Comment("Doctor Identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Identity User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;


        [Required]
        [Comment("Clinic Identifier")]
        public int ClinicId { get; set; }

        [ForeignKey(nameof(ClinicId))]
        public Clinic Clinic { get; set; } = null!;


        public IEnumerable<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
