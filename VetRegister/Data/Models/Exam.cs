using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        
        [Required]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }


        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }


        [Required]
        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

    }
}
