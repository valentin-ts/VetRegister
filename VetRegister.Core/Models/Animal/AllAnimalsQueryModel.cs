using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Core.Models.Animal
{
    public class AllAnimalsQueryModel
    {

        public IEnumerable<AnimalViewModel> Animals { get; set; } = new List<AnimalViewModel>();

        [Display(Name = "Name")]
        public string NameFilter { get; set; } = string.Empty;

        [Display(Name = "Specie")]
        public string SpecieFilter { get; set; } = string.Empty;

        public IEnumerable<AnimalSpecieViewModel> Species { get; set; } = new List<AnimalSpecieViewModel>();
        
        [Display(Name = "Date Of Birth")]
        public string DateOfBirthFilter { get; set; } = string.Empty;

        [Display(Name = "Age")]
        public string AgeFilter { get; set; } = string.Empty;

    }
}

