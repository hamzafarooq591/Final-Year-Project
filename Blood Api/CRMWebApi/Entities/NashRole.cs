namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashRole : AuditField
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public int RoleDisplayId { get; set; }
    }
}

