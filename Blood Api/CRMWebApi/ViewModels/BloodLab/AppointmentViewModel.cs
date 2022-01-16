using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.ViewModels.BloodLab
{
    public class AppointmentViewModel : IAuditFieldViewModel
    {
        public int? AppointmentId { get; set; }
        public string AppointmentStatus { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Comment { get; set; }

        public bool IsBookingForMyself { get; set; }

        public string AppointmentPatientName { get; set; }

        public string PatientPhoneNumber { get; set; }

        public string PatientGender { get; set; }
        public string PatientRelationship { get; set; }

        public List<TestViewModel> TestList { get; set; }
        public List<OfferViewModel> OfferList { get; set; }

        public int NumberOfResults { get; set; }
        public bool ResultPending { get; set; }

        public double TotalAmount { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}