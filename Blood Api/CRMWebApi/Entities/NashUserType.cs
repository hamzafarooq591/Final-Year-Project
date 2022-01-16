namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserType : AuditField
    {
        public string Description { get; set; }

        public string Name { get; set; }
    }
}

