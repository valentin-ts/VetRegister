using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetRegister.Core.Models.Animal
{
    public class AnimalFormModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; init; } = string.Empty;

        [Required]
        public string DateOfBirth{ get; init; } = string.Empty;

        [Required]
        public int SpecieId { get; set; }

        public IEnumerable<AnimalSpecieViewModel> Species { get; set; } = new List<AnimalSpecieViewModel>();
    }
}
