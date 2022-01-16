using NashWebApi.Entities.BloodLab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.ViewModels.BloodLab
{
    public class AppointmentOfferViewModel : IAuditFieldViewModel
    {
        public int? AppointmentOfferId { get; set; }
       
        public int AppointmentId { get; set; }

        public int OfferId { get; set; }

        public int PatientId { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}