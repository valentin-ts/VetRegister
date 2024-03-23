using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Procedure
    {
        [Key]
        [Comment("Procedure Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Procedure Description")]
        public string Description { get; set; } = string.Empty;

        [Comment("Procedure Creation Date")]
        public DateTime CreatedOn { get; set; }


        [Required]
        [Comment("Animal Identifier")]
        public int AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; } = null!;


        [Required]
        [Comment("Doctor Identifier")]
        public int DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}
