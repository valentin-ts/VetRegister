using System.ComponentModel.DataAnnotations;

namespace VetRegister.Core.Models.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; } = string.Empty;

        public int ProceduresCount { get; set; }
     }
}
