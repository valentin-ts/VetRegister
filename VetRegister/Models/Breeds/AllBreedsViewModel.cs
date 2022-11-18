using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Breeds
{
    public class AllBreedsViewModel
    {
        //public int BreedId { get; set; }


        public string NewBreedName { get; set; }

        public IEnumerable<SingleBreedViewModel> AllBreedsList { get; set; }
    }
}
