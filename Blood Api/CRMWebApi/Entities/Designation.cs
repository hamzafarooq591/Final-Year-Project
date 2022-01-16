namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class Designation : AuditField
    {
        public string DesignationDescription { get; set; }

        public string DesignationName { get; set; }

    }
}