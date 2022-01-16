using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NashWebApi.Entities
{
    public class Test :AuditField
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }

    }
}