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
        private static readonly string _baseAddress = "http://localhost:5000/";

        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };

        public void CreateVacation()
        {
            throw new NotImplementedException();
        }

        public async Task<VacationItemResult> UpdateVacation(VacationRequest vacation)
        {
            var content = new StringContent(JsonConvert.SerializeObject(vacation), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"vts/workflow", content);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<VacationItemResult>(await response.Content.ReadAsStringAsync());
            throw new Exception(response.ReasonPhrase);
        }

        public void DeleteVacation()
        {
            throw new NotImplementedException();
        }

        public async Task<VacationListResult> GetAllVacations()
        {
            var response = await _httpClient.GetAsync($"vts/workflow");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VacationListResult>(stringResult);
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<VacationItemResult> GetVacation(Guid vacationId)
        {
            var response = await _httpClient.GetAsync($"vts/workflow/{vacationId}");
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<VacationItemResult>(await response.Content.ReadAsStringAsync());
            throw new Exception(response.ReasonPhrase);
        }
    }
}
