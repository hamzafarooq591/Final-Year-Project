using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.BindingModels.BloodLab
{
    public class OfferBindingModel : ViewModels.IAuditFieldViewModel
    {
        public int? OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}