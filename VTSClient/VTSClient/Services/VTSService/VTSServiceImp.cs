using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService.DTO;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Services.VTSService
{
    public class VTSServiceImp : IVTSService
    {
        private static readonly string _baseAddress = "http://10.0.2.2:5000/";

        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };

        public async Task<VacationItemResult> UpdateVacation(VacationRequest vacation)
        {
            var content = new StringContent(JsonConvert.SerializeObject(vacation), Encoding.UTF8, "application/json");

            var response = await _httpClient
                .PostAsync($"vts/workflow", content)
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<VacationItemResult>(await response.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false));
            throw new Exception(response.ReasonPhrase);
        }

        public async void DeleteVacation(Guid vacationId)
        {
            var response = await _httpClient
                .DeleteAsync($"vts/workflow/{vacationId}")
                .ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);
        }

        public async Task<VacationListResult> GetAllVacations()
        {
            var response = await _httpClient
                .GetAsync($"vts/workflow")
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VacationListResult>(stringResult);
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<VacationItemResult> GetVacation(Guid vacationId)
        {
            var response = await _httpClient
                .GetAsync($"vts/workflow/{vacationId}")
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<VacationItemResult>(await response.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false));
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<bool> Login(string loginName, string password)
        {
            //{ "login" : "ark", "password" : "123" }

            dynamic jsonObject = new JObject();
            jsonObject.Login = loginName;
            jsonObject.Password = password;

            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient
                .PostAsync($"vts/signin", content)
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ResponseMessageResultBase>(await response.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false));
                return result.ResultCode == 0;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
