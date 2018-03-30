using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Services.VTSService.DTO
{
    public class ResponseMessageResultBase
    {
        [JsonProperty("Result")]
        public string Result { get; set; }

        [JsonProperty("ResultCode")]
        public int ResultCode { get; set; }
    }
}
