﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTSClient.Services.VTSService.DTO
{
    public class VacationListResult
    {
        [JsonProperty("listResult")]
        public List<VacationRequest> Vacations { get; set; }
    }
}