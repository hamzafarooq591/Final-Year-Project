namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class TestBindingModel
    {
        public int? TestId { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
    }
}

