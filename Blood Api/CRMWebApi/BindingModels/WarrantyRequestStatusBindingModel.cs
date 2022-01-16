namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyRequestStatusBindingModel
    {
        public int? WarrantyRequestStatusId { get; set; }

        public string StatusTitle { get; set; }

        public string StatusDescription { get; set; }

    }
}

