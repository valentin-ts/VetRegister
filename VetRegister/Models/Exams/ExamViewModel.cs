using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Exams
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public string AnimalName { get; set; }

        public string DoctorName { get; set; }

        public string ProcedureName { get; set; }
    }
}
