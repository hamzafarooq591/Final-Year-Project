 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterTemplateViewModel : IAuditFieldViewModel
    {
        public int NewsLetterTemplateId { get; set; }

        public string NewsSubject { get; set; }

        public string NewsTemplate { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

