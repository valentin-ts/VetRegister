using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
