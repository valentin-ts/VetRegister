using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Animal
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public bool GenderIsMale { get; set; }

        public DateTime DateOfBirth { get; set; }


        public int OwnerId { get; set; }

        public Owner Owner { get; set; }


        public int BreedId { get; set; }

        public Breed Breed { get; set; }


        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
    }
}
