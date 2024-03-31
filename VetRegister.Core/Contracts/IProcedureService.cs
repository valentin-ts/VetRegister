using VetRegister.Core.Models.Procedure;

namespace VetRegister.Core.Contracts
{
    public interface IProcedureService
    {
        public IEnumerable<ProcedureViewModel> GetAllProcedures();

        //public IEnumerable<ProcedureViewModel> GetDoctorProcedures(int doctorId);

        public void Add(ProcedureFormModel modelProcedure, int animalId, int doctorId);
    }
}
