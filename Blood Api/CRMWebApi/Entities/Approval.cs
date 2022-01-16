namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class Approval : AuditField
    {
        public string ApprovalDescription { get; set; }

        public string ApprovalTitle { get; set; }

    }
}