using NashWebApi.Entities;
using NashWebApi.Entities.BloodLab;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NashWebApi.BindingModels.BloodLab
{
    public class AppointmentTestResultBindingModel 
    {
        public int? AppointmentTestResultId { get; set; }
        public int AppointmentId { get; set; }
        public List<string> AppointmentTestResultFileList { get; set; }

    }
}