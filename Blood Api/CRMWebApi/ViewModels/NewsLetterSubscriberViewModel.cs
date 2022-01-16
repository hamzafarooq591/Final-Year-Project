 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsLetterSubscriberViewModel : IAuditFieldViewModel
    {
        public int NewsLetterSubscriberId { get; set; }

        public int NashUserId { get; set; }
        public string NashUserEmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

