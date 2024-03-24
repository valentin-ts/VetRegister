using System.ComponentModel.DataAnnotations;

namespace VetRegister.Core.Models.Procedure
{
    public class ProcedureFormModel
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string CreatedOn { get; set; } = string.Empty;


        //public string AnimalName { get; set; } = string.Empty;


        //public string DoctorName { get; set; } = string.Empty;

    }
}
