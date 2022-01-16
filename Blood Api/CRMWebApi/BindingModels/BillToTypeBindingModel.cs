namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class BillToTypeBindingModel
    {
        public string Description { get; set; }
        public int? BillToTypeId { get; set; }
        public string Title { get; set; }
    }
}

