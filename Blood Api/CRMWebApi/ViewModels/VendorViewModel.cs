﻿ namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class VendorViewModel : IAuditFieldViewModel
    {
        public int VendorId { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public string POCode { get; set; }

        public string VendorName { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string FaxNo { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public string LastModified { get; set; }
    }
}

