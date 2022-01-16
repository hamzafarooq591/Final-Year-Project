namespace NashWebApi.Extensions
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using System;
    using System.Runtime.CompilerServices;

    public static class ViewModelMapper
    {
        public static string GetFullName(this NashUser user)
        {
            if (user != null)
            {
                return $"{user.FirstName} {user.LastName}";
            }
            return string.Empty;
        }

        public static string GetFullName(this Employee user)
        {
            if (user != null)
            {
                return $"{user.EmployeeFName} {user.EmployeeLName}";
            }
            return string.Empty;
        }

        public static T MapAuditableFields<T>(this T view, AuditField model) where T: IAuditFieldViewModel
        {
            view.CreatedBy = model.CreatedByUserId.ToString();
            view.DateCreated = model.CreatedOn.FormatDate("MM/dd/yyyy hh:mm tt");
            view.LastModified = model.ModifiedByUserId.ToString();
            view.DateModified = model.ModifiedOn.FormatDate("MM/dd/yyyy hh:mm tt");
            return view;
        }

        public static T MapCreatedAndLastModifiedFields<T>(this T model, int modifiedById) where T: IAuditField
        {
            model.CreatedOn = DateTime.UtcNow;
            model.CreatedByUserId = new int?(modifiedById);
            model.ModifiedOn = DateTime.UtcNow;
            model.ModifiedByUserId = new int?(modifiedById);
            return model;
        }

        public static T MapLastModifiedFields<T>(this T model, int modifiedById) where T: IAuditField
        {
            model.ModifiedOn = DateTime.UtcNow;
            model.ModifiedByUserId = new int?(modifiedById);
            return model;
        }
    }
}

