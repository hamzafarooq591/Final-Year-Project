namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyModeBindingModel
    {
        public int? WarrantyModeId { get; set; }

        public string WarrantyModePeriod { get; set; }

        public int WarrantyModePeriodInDays { get; set; }

        public bool IsActive { get; set; }
    }
}

