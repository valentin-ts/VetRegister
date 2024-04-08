using VetRegister.Core.Models.Procedure;

namespace VetRegister.Core.Contracts
{
    public interface IProcedureService
    {
        public Task<IEnumerable<ProcedureViewModel>> GetAllProceduresAsync();

        //public Task<IEnumerable<ProcedureViewModel>> GetDoctorProceduresAsync(int doctorId);

        public Task AddProcedureAsync(ProcedureFormModel modelProcedure, int animalId, int doctorId);
    }
}
