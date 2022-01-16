using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities.BloodLab
{
    public class Offer :AuditField
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }


    }
}