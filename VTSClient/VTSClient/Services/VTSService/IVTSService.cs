using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService.DTO;

namespace VTSClient.Services.VTSService
{
    public interface IVTSService
    {
        Task<IEnumerable<VacationRequest>> GetAllVacations();

        Task<VacationRequest> GetVacation(Guid vacationId);

        void CreateVacation();

        void UpdateVacation();

        void DeleteVacation();
    }
}
