using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTSClient.Services.VTSService.DTO
{
    public class VacationItemResult
    {
        [JsonProperty("itemResult")]
        public VacationRequest Vacation { get; set; }
    }
}
