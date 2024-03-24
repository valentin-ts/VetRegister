//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Core.Models.Specie
{
    public class SpecieFormModel
    {
        [Required]
        [MaxLength(20)]
        public string NewSpecieName { get; set; } = string.Empty;

        public IEnumerable<SpecieViewModel> AllSpeciesList { get; set; } = new List<SpecieViewModel>();
    }
}
