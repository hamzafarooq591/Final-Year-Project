 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailTemplateTypeViewModel : IAuditFieldViewModel
    {
        public int EmailTemplateTypeId { get; set; }

        public string TemplateType { get; set; }

        public string TemplateDescription { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

