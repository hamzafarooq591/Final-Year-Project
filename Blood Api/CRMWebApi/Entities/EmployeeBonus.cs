namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class EmployeeBonus : AuditField
    {

        public DateTime BonusMonth { get; set; }

        public string BonusOccasion { get; set; }

        public float BonusAmount { get; set; }

        [ForeignKey("EmployeeId")]
        public NashWebApi.Entities.Employee Employee { get; set; }
        public int EmployeeId { get; set; }

    }
}

