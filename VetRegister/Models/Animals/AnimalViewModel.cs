using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Models.Exams;

namespace VetRegister.Models.Animals
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; init; }

        public string DateOfBirth { get; init; }

        public string Age { get; set; }

        public int BreedId { get; set; }

        public string BreedName { get; set; }

        public IEnumerable<ExamViewModel> Exams { get; set; }
    }
}
