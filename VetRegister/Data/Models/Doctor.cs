using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Doctor : Person
    {
        [MaxLength(20)]
        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();


        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }
    }
}
