﻿ namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class VendorPODetailViewModel : IAuditFieldViewModel
    {
        public int VendorPODetailId { get; set; }

        public int VendorPurchaseOrderId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public float UnitCostUSD { get; set; }

        public float TotalCostCFRUSD { get; set; }
        public float LandingChargesUSD { get; set; }
        public float InsuranceChargesUSD { get; set; }
        public float OtherChargesUSD { get; set; }
        public float ImportValueUSD { get; set; }

        public float ImportValuePKR { get; set; }
        public float CustomDutiesPKR { get; set; }
        public float SalesTaxPKR { get; set; }
        public float AddSalesTaxPKR { get; set; }
        public float IncomeTaxPKR { get; set; }
        public float TotalDutiesPKR { get; set; }

        public float PenaltyCharges { get; set; }
        public float CESS { get; set; }
        public float CustomMisc { get; set; }
        public float Wharfage { get; set; }
        public float DOCharges { get; set; }
        public float FreightCharges { get; set; }
        public float ClearingCharges { get; set; }
        public float OtherCharges { get; set; }

        public float TotalCostPKR { get; set; }
        public float UnitCostPKR { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }

    }
}

