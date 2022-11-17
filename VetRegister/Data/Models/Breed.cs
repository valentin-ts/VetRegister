using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Breed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Animal> Animals { get; set; } = new List<Animal>();
    }
}
