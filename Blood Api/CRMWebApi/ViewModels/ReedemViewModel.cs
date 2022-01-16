namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class ReedemViewModel : IAuditFieldViewModel
    {
        public int ReedemId { get; set; }
        public int nashUserId { get; set; }
        public string nashUserName { get; set; }
        public int ReedemOfferId { get; set; }
        public int ReedemOfferTitle { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }


}

