 namespace NashWebApi.ViewModels.BloodLab
{
    using System;
    using System.Runtime.CompilerServices;

    public class TestViewModel : IAuditFieldViewModel
    {
        public int TestId { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

