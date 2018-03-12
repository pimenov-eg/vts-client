using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.DAL
{
    public interface IVTSDataAccess
    {
        void StoreAllVacations(List<VacationRequest> vacations);

        int StoreVacation(VacationRequest vacation);

        IEnumerable<VacationRequest> GetAllVacations();

        VacationRequest GetVacation(Guid id);

        int DeleteVacation(Guid id);
    }
}
