using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService.DTO;

namespace VTSClient.Services.VTSService
{
    public class VTSServiceImp : IVTSService
    {
        private static readonly string BaseUri = "http://localhost:5000/vts/workflow";

        public void CreateVacation()
        {
            throw new NotImplementedException();
        }

        public void UpdateVacation()
        {
            throw new NotImplementedException();
        }

        public void DeleteVacation()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VacationRequest>> GetAllVacations()
        {
            var client = new HttpClient();
            var resultString = await client.GetStringAsync(BaseUri);

            var result = JsonConvert.DeserializeObject<List<VacationRequest>>(resultString);
            return result;
        }

        public async Task<VacationRequest> GetVacation(Guid vacationId)
        {
            var client = new HttpClient();
            var resultString = await client.GetStringAsync($"{BaseUri}/{vacationId}");

            var result = JsonConvert.DeserializeObject<VacationRequest>(resultString);
            return result;
        }
    }
}
