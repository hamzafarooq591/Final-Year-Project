namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CustomerBindingModel
    {

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhoneNo { get; set; }

        public string CustomerCompanyName { get; set; }
        public bool isTransporter { get; set; }


    }
}

