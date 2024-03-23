namespace VetRegister.Core.Models.Clinic
{
    public class ClinicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public IEnumerable<string> Doctors { get; set; } = new List<string>();
    }
}
