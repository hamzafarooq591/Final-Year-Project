using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class AppointmentTest : AuditField
    {
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}