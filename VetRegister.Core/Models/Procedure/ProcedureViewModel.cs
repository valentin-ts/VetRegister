namespace VetRegister.Core.Models.Procedure
{
    public class ProcedureViewModel
    {
        public int Id { get; set; }

        public string CreatedOn { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty; 

        public string AnimalName { get; set; } = string.Empty;

        public string DoctorName { get; set; } = string.Empty;

    }
}
