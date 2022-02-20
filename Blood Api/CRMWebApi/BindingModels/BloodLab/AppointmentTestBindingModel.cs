using NashWebApi.Entities;
using NashWebApi.Entities.BloodLab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.BindingModels.BloodLab
{
    public class AppointmentTestBindingModel 
    {
        public int? AppointmentTestId { get; set; }
        public int AppointmentId { get; set; }
        public int TestId { get; set; }
        public decimal Price { get; set; }

    }
}