using System.ComponentModel.DataAnnotations;
using VetRegister.Core.Models.Procedure;


namespace VetRegister.Core.Models.Animal
{
    public class AnimalViewModel
    {
        public int Id { get; set; }

        public string Name { get; init; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; init; } = string.Empty;

        public string Age { get; set; } = string.Empty;

        public int SpecieId { get; set; }

        public string SpecieName { get; set; } = string.Empty;

        public IEnumerable<ProcedureViewModel> Procedures { get; set; }  = new List<ProcedureViewModel>();
    }
}
