namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashAclBindingModel
    {
        public bool IsAddAllowed { get; set; }

        public bool IsDeleteAllowed { get; set; }

        public bool IsEditAllowed { get; set; }

        public bool IsViewAllowed { get; set; }

        public int? NashAclId { get; set; }

        public int PageId { get; set; }

        public int RoleId { get; set; }
    }
}

