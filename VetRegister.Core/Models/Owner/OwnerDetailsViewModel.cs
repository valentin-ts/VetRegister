using VetRegister.Core.Models.Animal;

namespace VetRegister.Core.Models.Owner
{
    public class OwnerDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public IEnumerable<AnimalViewModel> Animals = new List<AnimalViewModel>();
    }
}
