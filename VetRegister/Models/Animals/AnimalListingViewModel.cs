using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Animals
{
    public class AnimalListingViewModel
    {
        public int Id { get; set; }
        public string Name { get; init; }

        public string Owner { get; init; }

        public int Age { get; init; }

        public int BreedId { get; set; }

        public string BreedName { get; set; }
    }
}
