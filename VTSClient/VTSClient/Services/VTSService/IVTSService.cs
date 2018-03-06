using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService.DTO;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Services.VTSService
{
    public interface IVTSService
    {
        Task<VacationListResult> GetAllVacations();

        Task<VacationItemResult> GetVacation(Guid vacationId);

        Task<VacationItemResult> UpdateVacation(VacationRequest vacation);

        void DeleteVacation(Guid vacationId);
    }
}
