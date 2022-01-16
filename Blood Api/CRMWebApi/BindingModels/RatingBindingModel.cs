namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class RatingBindingModel
    {
        public string FeedBack { get; set; }

        public bool IsApproved { get; set; }

        public int RatingById { get; set; }

        public int? RatingId { get; set; }

        public int RatingToId { get; set; }

        public int RatingTypeId { get; set; }

        public int RatingValue { get; set; }
    }
}

