using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRegister.Models.Exams
{
    public class ExamFormModel
    {
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public int ProcedureId { get; set; }

        public string ProcedureName { get; set; }

        public IEnumerable<ExamProcedureViewModel> Procedures { get; set; }

    }
}
