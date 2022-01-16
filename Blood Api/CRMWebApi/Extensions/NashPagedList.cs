namespace NashWebApi.Extensions
{
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class NashPagedList<T> : IPagedList
    {
        public NashPagedList(IPagedList<T> pagedList)
        {
            this.IsSuccess = true;
            this.Data = pagedList.ToList<T>();
            this.PageCount = pagedList.PageCount;
            this.TotalItemCount = pagedList.TotalItemCount;
            this.PageNumber = pagedList.PageNumber;
            this.PageSize = pagedList.PageSize;
            this.HasPreviousPage = pagedList.HasPreviousPage;
            this.HasNextPage = pagedList.HasNextPage;
            this.IsFirstPage = pagedList.IsFirstPage;
            this.IsLastPage = pagedList.IsLastPage;
            this.FirstItemOnPage = pagedList.FirstItemOnPage;
            this.LastItemOnPage = pagedList.LastItemOnPage;
        }

        public NashPagedList(IList<T> list, IPagedList pagedList)
        {
            this.IsSuccess = true;
            this.Data = list;
            this.PageCount = pagedList.PageCount;
            this.TotalItemCount = pagedList.TotalItemCount;
            this.PageNumber = pagedList.PageNumber;
            this.PageSize = pagedList.PageSize;
            this.HasPreviousPage = pagedList.HasPreviousPage;
            this.HasNextPage = pagedList.HasNextPage;
            this.IsFirstPage = pagedList.IsFirstPage;
            this.IsLastPage = pagedList.IsLastPage;
            this.FirstItemOnPage = pagedList.FirstItemOnPage;
            this.LastItemOnPage = pagedList.LastItemOnPage;
        }

        public IList<T> Data { get; set; }

        public int FirstItemOnPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public bool IsSuccess { get; set; }

        public int LastItemOnPage { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }
    }
}

