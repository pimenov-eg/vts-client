using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.DAL
{
    public abstract class VTSDataAccessImpBase : IVTSDataAccess
    {
        protected abstract string DbPath { get; }

        private SQLiteConnection Db { get; }

        public VTSDataAccessImpBase()
        {
            Db = new SQLiteConnection(Path.Combine(DbPath, "VacationStore.db"));
            Db.CreateTable<VacationRequest>();
        }

        public void StoreAllVacations(List<VacationRequest> vacations)
        {
            foreach (var vacation in vacations)
                StoreVacation(vacation);
        }

        public int StoreVacation(VacationRequest vacation)
        {
            var existingVacation = GetVacation(vacation.Id);

            if (existingVacation is null)
                return CreateVacation(vacation);

            existingVacation.Start = vacation.Start;
            existingVacation.End = vacation.End;
            existingVacation.Created = vacation.Created;
            existingVacation.CreatedBy = vacation.CreatedBy;
            existingVacation.VacationType = vacation.VacationType;
            existingVacation.VacationStatus = vacation.VacationStatus;

            return UpdateVacation(existingVacation);
        }

        public IEnumerable<VacationRequest> GetAllVacations()
        {
            return Db.Table<VacationRequest>();
        }

        public VacationRequest GetVacation(Guid id)
        {
            return Db.Find<VacationRequest>(id);
        }

        public int DeleteVacation(Guid id)
        {
            return Db.Delete<VacationRequest>(id);
        }

        private int CreateVacation(VacationRequest vacation)
        {
            return Db.Insert(vacation);
        }

        private int UpdateVacation(VacationRequest vacation)
        {
            return Db.Update(vacation);
        }
    }
}