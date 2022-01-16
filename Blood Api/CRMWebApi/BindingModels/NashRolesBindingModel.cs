namespace NashWebApi.BindingModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashRolesBindingModel
    {
        public string Description { get; set; }
        public int? NashRolesId { get; set; }
        public string Name { get; set; }
        public int RoleDisplayId { get; set; }
    }
}

