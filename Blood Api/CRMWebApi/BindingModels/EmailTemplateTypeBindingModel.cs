namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class EmailTemplateTypeBindingModel
    {
        public int? EmailTemplateTypeId { get; set; }

        public string TemplateType { get; set; }

        public string TemplateDescription { get; set; }

    }
}

