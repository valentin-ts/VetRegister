using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Animals
{
    public class AddAndEditAnimalFormModel
    {
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Name { get; init; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Owner { get; init; }

        [Required]
        public int Age { get; init; }

        [Required]
        public int BreedId { get; set; }

        public string BreedName { get; set; }

        //[Required]
        public IEnumerable<AnimalBreedViewModel> Breeds { get; set; }
    }
}
