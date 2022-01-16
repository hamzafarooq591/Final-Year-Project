namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyBindingModel
    {
        public int? WarrantyId { get; set; }

        public int OrderId { get; set; }

        public int BranchId { get; set; }

        public int CustomerId { get; set; }

        public string SerialMAC { get; set; }

        public string ReplacementSerialMAC { get; set; }

        public int WarrantyModeId { get; set; }

        public DateTime WarrantyStartDate { get; set; }

        public DateTime WarrantyEndDate { get; set; }
    }
}
