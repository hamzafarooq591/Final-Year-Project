namespace NashWebApi.ViewModels
{
    using System;

    public interface IAuditFieldViewModel
    {
        string CreatedBy { get; set; }

        string DateCreated { get; set; }

        string DateModified { get; set; }

        string LastModified { get; set; }
    }
}

