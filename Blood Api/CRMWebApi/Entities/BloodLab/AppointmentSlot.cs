using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class AppointmentSlot :AuditField
    {   
        public string SlotTime { get; set; }

    }
}