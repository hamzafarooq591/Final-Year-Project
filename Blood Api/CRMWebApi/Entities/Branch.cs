namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class Branch : AuditField
    {
        public string BranchDescription { get; set; }
        public string BranchName { get; set; }

        [ForeignKey("CompanyId")]
        public NashWebApi.Entities.NashCompany Company { get; set; }
        public int CompanyId { get; set; }
    }
}

