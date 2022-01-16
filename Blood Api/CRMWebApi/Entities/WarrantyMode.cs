namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class WarrantyMode : AuditField
    {

        public string WarrantyModePeriod { get; set; }

        public int WarrantyModePeriodInDays { get; set; }

        public bool IsActive { get; set; }

    }
}
