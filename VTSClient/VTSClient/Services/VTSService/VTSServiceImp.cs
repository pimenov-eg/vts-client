﻿using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService.DTO;

namespace VTSClient.Services.VTSService
{
    public class VTSServiceImp : IVTSService
    {
        public void CreateVacation()
        {
            throw new NotImplementedException();
        }

        public void DeleteVacation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VacationRequest> GetAllVacations()
        {
            throw new NotImplementedException();
        }

        public VacationRequest GetVacation()
        {
            return new VacationRequest { CreatedBy = "User", VacationStatus = VacationStatus.Approved };
        }

        public void UpdateVacation()
        {
            throw new NotImplementedException();
        }
    }
}
