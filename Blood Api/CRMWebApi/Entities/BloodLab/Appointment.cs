using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class Appointment :AuditField
    {
        public string AppointmentStatus { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }

        public bool IsBookingForMyself { get; set; }

        public string AppointmentPatientName { get; set; }

        public string PatientPhoneNumber { get; set; }

        public string PatientGender { get; set; }
        public string PatientRelationship { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public string Comment { get; set; }

        public double TotalAmount { get; set; } 


    }
}