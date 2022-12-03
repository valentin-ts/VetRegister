using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Breeds
{
    public class BreedFormModel
    {
        [MaxLength(20)]
        public string NewBreedName { get; set; }

        public IEnumerable<BreedViewModel> AllBreedsList { get; set; }
    }
}
