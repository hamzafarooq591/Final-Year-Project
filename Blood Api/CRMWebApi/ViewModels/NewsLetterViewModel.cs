 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterViewModel : IAuditFieldViewModel
    {
        public int NewsLetterId { get; set; }

        public string NewsLetterSubject { get; set; }

        public string NewsLetterBody { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

