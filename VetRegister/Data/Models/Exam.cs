using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Data.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }


        public int AnimalId { get; set; }

        public Animal Animal { get; set; }


        public int PersonId { get; set; }

        public Person Person { get; set; }


        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

    }
}
