namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class WarrantyOrRepairRequestBindingModel
    {
        public int? WarrantyOrRepairRequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public string MacAddress { get; set; }

        public string ProblemType { get; set; }

        public string Comments { get; set; }

        public int ProductId { get; set; }
        
        public int BranchId { get; set; }

        public int CustomerId { get; set; }

        public int WarrantyStatusId { get; set; }

    }
}

