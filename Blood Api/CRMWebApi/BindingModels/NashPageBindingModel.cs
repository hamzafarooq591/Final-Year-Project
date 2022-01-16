namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashPageBindingModel
    {
        public string Description { get; set; }

        public int? NashPageId { get; set; }

        public int? ParentPageId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

