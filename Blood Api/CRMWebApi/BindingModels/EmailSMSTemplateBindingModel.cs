namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailSMSTemplateBindingModel
    {
        public int? EmailSMSTemplateId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailTemplate { get; set; }

        public int EmailTemplateTypeId { get; set; }
    }
}

