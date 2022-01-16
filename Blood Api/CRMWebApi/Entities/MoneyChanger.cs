namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class MoneyChanger : AuditField
    {
        [ForeignKey("MCAccountId")]
        public NashWebApi.Entities.Account Account { get; set; }
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

