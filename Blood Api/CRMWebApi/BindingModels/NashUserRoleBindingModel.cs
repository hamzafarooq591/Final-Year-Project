namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserRoleBindingModel
    {
        public int NashRoleId { get; set; }

        public int NashUserId { get; set; }

        public int? NashUserRoleId { get; set; }
    }
}

