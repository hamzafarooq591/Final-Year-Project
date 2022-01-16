namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class ClearingAgent : AuditField
    {
        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company { get; set; }
        public int CompanyId { get; set; }

        public string CAName { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string FaxNo { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
        
    }
}

