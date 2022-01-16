namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class RatingViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string FeedBack { get; set; }

        public bool IsApproved { get; set; }

        public string LastModified { get; set; }

        public int RatingById { get; set; }

        public string RatingByName { get; set; }

        public int? RatingId { get; set; }

        public int RatingToId { get; set; }

        public string RatingToName { get; set; }

        public int RatingTypeId { get; set; }

        public string RatingTypeName { get; set; }

        public int RatingValue { get; set; }
    }
}

