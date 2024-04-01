using System.ComponentModel.DataAnnotations;

namespace VetRegister.Core.Models.Owner
{
    public class BecomeOwnerFormModel
    {
        [MaxLength(20)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
