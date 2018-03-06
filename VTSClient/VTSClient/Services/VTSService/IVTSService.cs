using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService.DTO;

namespace VTSClient.Services.VTSService
{
    public interface IVTSService
    {
        Task<VacationListResult> GetAllVacations();

        Task<VacationItemResult> GetVacation(Guid vacationId);

        void CreateVacation();

        Task<VacationItemResult> UpdateVacation(VacationRequest vacation);

        void DeleteVacation();
    }
}
