using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.BindingModels.BloodLab
{
    public class AppointmentSlotBindingModel : ViewModels.IAuditFieldViewModel
    {
        public int? AppointmentSlotId { get; set; }

        public string SlotTime { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
    public class AppointmentSlotViewModelts
    {
        public string Address { get; set; }

        public string City { get; set; }
        public string AppointmentDateTime { get; set; }
        public string Comment { get; set; }
        public string Slot { get; set; }
        public bool IsBookingForMyself { get; set; }
       
        public string AppointmentPatientName { get; set; }
        public string PatientPhoneNumber { get; set; }
        public string PatientGender { get; set; }
        public string PatientRelationship { get; set; }
        public string PatNumber { get; set; }
        public string PatPassword { get; set; }
        public double Total { get; set; }
        

        public List<AppointmentBill> Value { get; set; }

    }
    public class AppointmentBill
    {
        public string name { get; set; }

        public double price { get; set; }
       

    }
}