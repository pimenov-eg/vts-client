using SQLite;
using System;

namespace VTSClient.Services.VTSService.Entities
{
    public class VacationRequest
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public VacationType VacationType { get; set; }
        public VacationStatus VacationStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
