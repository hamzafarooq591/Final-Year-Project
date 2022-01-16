using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class AppointmentOffer :AuditField
    {
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }

        [ForeignKey("OfferId")]
        public Offer Offer { get; set; }
        public int OfferId { get; set; } 
    }
}