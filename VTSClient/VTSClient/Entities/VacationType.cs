using System;
using System.Collections.Generic;
using System.Text;

namespace VTSClient.Services.VTSService.Entities
{
    public enum VacationType
    {
        Undefined = 0,
        Regular = 1,
        Sick = 2,
        Exceptional = 3,
        LeaveWithoutPay = 4,
        Overtime = 5
    }
}
