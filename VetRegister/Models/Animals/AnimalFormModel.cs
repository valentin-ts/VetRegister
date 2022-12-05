using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VetRegister.Models.Exams;

namespace VetRegister.Models.Animals
{
    public class AnimalFormModel
    {
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Name { get; init; }

        [Required]
        public string DateOfBirth{ get; init; }

        [Required]
        public int BreedId { get; set; }

        public IEnumerable<AnimalBreedViewModel> Breeds { get; set; }
    }
}
