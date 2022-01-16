namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IImageUploadRepository : IRepository<ImageUpload>
    {
        IPagedList<ImageUpload> Filter(int rows, int pageNumber);
        IQueryable<ImageUpload> FindOne(int ImageUploadId);
        ImageUploadViewModel FindOneMapped(int ImageUploadId);
    }
}

