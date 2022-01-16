namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class DcSummaryBindingModel
    {
        public int? DcSummaryId { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public int DcGroupId { get; set; }

        public string DcSummaryDate { get; set; }

        public int Transfered { get; set; }

        public int Received { get; set; }
    }
}