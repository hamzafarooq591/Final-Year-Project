namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProductWarrantyBindingModel
    {
        public int? ProductWarrantyId { get; set; }

        public int ProductId { get; set; }

        public int WarrantyModeId { get; set; }

        public string SerialMAC { get; set; }
    }
}
