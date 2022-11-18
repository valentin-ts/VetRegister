using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Animals
{
    public class AllAnimalsQueryModel
    {

        public IEnumerable<AnimalListingViewModel> Animals { get; set; }

        [Display(Name = "Name")]
        public string NameFilter { get; set; }

        [Display(Name = "Breed")]
        public string BreedFilter { get; set; }

        public IEnumerable<string> Breeds { get; set; }

        [Display(Name = "Age")]
        public string AgeFilter { get; set; }

        [Display(Name = "Owner")]
        public string OwnerFilter { get; set; }


    }
}

