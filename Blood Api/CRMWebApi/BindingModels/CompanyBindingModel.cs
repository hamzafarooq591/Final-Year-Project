namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class CompanyBindingModel
    {
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }

        public int ImageId { get; set; }
        public string CompanyImageUpload { get; set; }

    }
}

