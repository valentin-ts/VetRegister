using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Animals
{
    public class AddAnimalFormModel
    {
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Name { get; init; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Owner { get; init; }

        public int Age { get; init; }

        public int BreedId { get; set; }

        //public Breed Breed { get; set; }

        //[Required]
        public IEnumerable<AnimalBreedViewModel> Breeds { get; set; }
    }
}
