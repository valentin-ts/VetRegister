using System.ComponentModel.DataAnnotations;
using VetRegister.Core.Models.Procedure;

namespace VetRegister.Core.Models.Doctor
{
    public class DoctorDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; } = string.Empty;

        public IEnumerable<ProcedureViewModel> Procedures = new List<ProcedureViewModel>();
    }
}
