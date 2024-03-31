namespace VetRegister.Core.Models.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClinicName { get; set; }

        public int ProceduresCount { get; set; }
     }
}
