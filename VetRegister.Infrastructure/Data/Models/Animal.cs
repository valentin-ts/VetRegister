using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Animal
    {
        [Key]
        [Comment("Animal Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("Animal Name")]
        public string Name { get; set; } = string.Empty;

        [Comment("Animal Gender Is Male")]
        public bool GenderIsMale { get; set; }

        [Comment("Animal Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Comment("Owner Identifier")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; } = null!;

        [Comment("Specie Identifier")]
        public int SpecieId { get; set; }

        [ForeignKey(nameof(SpecieId))]
        public Specie Specie { get; set; } = null!;

        public IEnumerable<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
