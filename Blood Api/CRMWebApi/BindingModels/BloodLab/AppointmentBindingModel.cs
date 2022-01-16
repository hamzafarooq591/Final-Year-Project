using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.BindingModels.BloodLab
{
    public class AppointmentBindingModel : ViewModels.IAuditFieldViewModel
    {
        public int? AppointmentId { get; set; }
        public string AppointmentStatus { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public int PatientId { get; set; }
        public string Comment { get; set; }
        public bool IsBookingForMyself { get; set; }

        public string AppointmentPatientName { get; set; }

        public string PatientPhoneNumber { get; set; }

        public string PatientGender { get; set; }
        public string PatientRelationship { get; set; }

        public List<AppointmentTestBindingModel> TestList { get; set; }
        public List<AppointmentOfferBindingModel> OfferList { get; set; }
        public double TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}