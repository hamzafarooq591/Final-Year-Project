namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaymentTypeBindingModel
    {
        public string Description { get; set; }
        public int? PaymentTypeId { get; set; }
        public string Title { get; set; }
    }
}

