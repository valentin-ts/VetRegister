using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Specie
    {
        [Key]
        [Comment("Specie Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpecieNameMaxLenght)]
        [Comment("Specie Name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Animal> Animals { get; set; } = new List<Animal>();
    }
}
