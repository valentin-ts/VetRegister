using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static VetRegister.Infrastructure.Constants.DataConstants;

namespace VetRegister.Infrastructure.Data.Models
{
    public class Owner
    {
        [Key]
        [Comment("Owner Identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Identity User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;


        [MaxLength(AddressMaxLenght)]
        [Comment("Owner Address")]
        public string Address { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Owner Phone Number")]
        public string PhoneNumber { get; set; }

        public IEnumerable<Animal> Animals { get; set; } = new List<Animal>();
    }
}
