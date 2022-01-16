 namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class PaymentTypeViewModel : IAuditFieldViewModel
    {
        
        public int PaymentTypeId { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

