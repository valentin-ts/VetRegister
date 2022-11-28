using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();
    }
}
