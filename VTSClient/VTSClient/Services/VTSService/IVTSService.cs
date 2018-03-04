using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService.DTO;

namespace VTSClient.Services.VTSService
{
    public interface IVTSService
    {
        IEnumerable<VacationRequest> GetAllVacations();

        VacationRequest GetVacation();

        void CreateVacation();

        void UpdateVacation();

        void DeleteVacation();
    }
}
