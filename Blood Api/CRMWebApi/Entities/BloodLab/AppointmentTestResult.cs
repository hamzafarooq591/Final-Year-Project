using NashWebApi.Entities.BloodLab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class AppointmentTestResult :AuditField
    {
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentTestResultImageId")]
        public ImageUpload AppointmentTestResultImage { get; set; }
        public int AppointmentTestResultImageId { get; set; }
    }
}