namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NewsListBindingModel
    {
        public int? NewsListId { get; set; }

        public string NewsListTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsPublished { get; set; }

    }
}

