namespace NashWebApi.Exceptions
{
    using Microsoft.CSharp.RuntimeBinder;
    using NashWebApi.Exceptions.NashHandledException;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class DataActionResponseFactory
    {
        public static DataActionResponse CreateDataActionResponseFailed(string errorMessage, object data = null) => 
            new DataActionResponse { 
                IsSuccessful = false,
                ErrorMessage = errorMessage,
                Data = data
            };

      
        public static DataActionResponse CreateDataActionResponseSuccess(this object data) => 
            new DataActionResponse { 
                IsSuccessful = true,
                Data = data
            };

        public static DataActionResponse CreateDataActionResponseSuccessForDelete(this object data, Dictionary<string, object> propertNameValueList)
        {
            IDictionary<string, object> dictionary = new ExpandoObject();
            foreach (KeyValuePair<string, object> pair in propertNameValueList)
            {
                dictionary.Add(pair.Key, pair.Value);
            }
            return new DataActionResponse { 
                IsSuccessful = true,
                Data = dictionary
            };
        }

        public static DataActionResponse CreateDataActionResponseSuccessForDelete(this object data, string propertyName, object value)
        {
            IDictionary<string, object> dictionary = new ExpandoObject();
            dictionary.Add(propertyName, value);
            
            return new DataActionResponse { 
                IsSuccessful = true,
                Data = dictionary
            };
        }

    }
}

