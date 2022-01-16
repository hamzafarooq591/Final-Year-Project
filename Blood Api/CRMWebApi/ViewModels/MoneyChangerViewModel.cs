 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class MoneyChangerViewModel : IAuditFieldViewModel
    {
        public int MoneyChangerId { get; set; }

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


        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

