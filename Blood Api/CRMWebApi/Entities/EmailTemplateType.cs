namespace NashWebApi.Entities
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailTemplateType : AuditField
    {
        public string TemplateType { get; set; }

        public string TemplateDescription { get; set; }

    }
}