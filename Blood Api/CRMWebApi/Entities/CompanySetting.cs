namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class CompanySetting : AuditField
    {

        public decimal MundRateInKG { get; set; }

    }
}