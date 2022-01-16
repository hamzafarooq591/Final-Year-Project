namespace NashWebApi.ViewModels
{
    using System;
    using System.Runtime.CompilerServices;

    public class NashUserRoleViewModel : IAuditFieldViewModel
    {
        public string CreatedBy { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string LastModified { get; set; }

        public int NashRoleId { get; set; }

        public string NashRoleName { get; set; }

        public int NashUserId { get; set; }

        public string NashUserName { get; set; }

        public int NashUserRoleId { get; set; }
    }
}

