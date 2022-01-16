namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class ImageUploadRepository : Repository<ImageUpload>, IImageUploadRepository, IRepository<ImageUpload>
    {
        public ImageUploadRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<ImageUpload> Filter(int rows, int pageNumber)
        {
            return NashContext.ImageUploads
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<ImageUpload>(pageNumber, rows);

        }

        public IQueryable<ImageUpload> FindOne(int ImageUploadId)
        {

            return NashContext.ImageUploads
                .Where(x => x.Id == ImageUploadId && x.IsDeleted == false);
        }

        public ImageUploadViewModel FindOneMapped(int ImageUploadId) => 
            this.FindOne(ImageUploadId).FirstOrDefault<ImageUpload>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

