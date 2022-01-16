namespace NashWebApi.Extensions
{
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class NashPagedListExtentions
    {
        public static NashPagedList<T> ToNashPagedList<T>(this IList<T> list, IPagedList metdaData) => 
            new NashPagedList<T>(list, metdaData);
    }
}

