using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTSClient.Services.VTSService.DTO
{
    public class VacationRequest
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public VacationType VacationType { get; set; }
        public VacationStatus VacationStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
