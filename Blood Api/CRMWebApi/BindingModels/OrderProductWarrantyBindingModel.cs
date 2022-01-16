namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class OrderProductWarrantyBindingModel
    {
        public int? OrderProductWarrantyId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string MacAddress { get; set; }
    }
}

