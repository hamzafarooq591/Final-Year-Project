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
}