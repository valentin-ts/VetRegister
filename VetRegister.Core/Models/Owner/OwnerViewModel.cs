﻿using VetRegister.Core.Models.Animal;

namespace VetRegister.Core.Models.Owner
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int AnimalsCount { get; set; }

        public IEnumerable<AnimalViewModel> Animals = new List<AnimalViewModel>();
    }
}
