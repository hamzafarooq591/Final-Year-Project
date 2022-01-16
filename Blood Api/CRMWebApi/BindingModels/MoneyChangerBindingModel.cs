namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class MoneyChangerBindingModel
    {
        public int? MoneyChangerId { get; set; }

        public int MCAccountId { get; set; }

        public string MCName { get; set; }

        public string MCEmail { get; set; }

        public string MobileNo { get; set; }

        public string TelNo { get; set; }

        public string FaxNo { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}

