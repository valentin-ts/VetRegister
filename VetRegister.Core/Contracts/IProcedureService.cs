using VetRegister.Core.Models.Procedure;

namespace VetRegister.Core.Contracts
{
    public interface IProcedureService
    {
        public IEnumerable<ProcedureViewModel> GetAllProcedures();

        public void Add(ProcedureFormModel modelProcedure, int animalId, int doctorId);
    }
}
