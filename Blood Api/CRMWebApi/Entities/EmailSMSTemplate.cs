namespace NashWebApi.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    public class EmailSMSTemplate : AuditField
    {
        public string EmailSubject { get; set; }
        public string EmailTemplate { get; set; }

        [ForeignKey("EmailTemplateTypeId")]
        public NashWebApi.Entities.EmailTemplateType EmailTemplateType { get; set; }
        public int EmailTemplateTypeId { get; set; }
    }
}

