namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class NashUserRepository : Repository<NashUser>, INashUserRepository, IRepository<NashUser>
    {
        public NashUserRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NashUser> Filter(int rows, int pageNumber, int? nashUserTypeId ,string SearchString = "")
        {
            var result = NashContext.NashUsers
               .Include(x => x.NashUserType)
               .Include(x => x.Gender)
               .Include(x => x.City)
               .Include(x => x.Branch)
               .Where(x => x.IsDeleted == false && (SearchString == "" || x.FirstName.Contains(SearchString) || x.LastName.Contains(SearchString)));
            if (nashUserTypeId.HasValue)
            {
                result = result
                    .Where(x => x.NashUserTypeId == nashUserTypeId);
            }

            return result.OrderByDescending(o => o.Id)
                .ToPagedList<NashUser>(pageNumber, rows);
           
        }


        public IQueryable<NashUser> FindOne(int nashUserId)
        {

            return NashContext.NashUsers
                .Include(x => x.NashUserType)
                .Include(x => x.Gender)
                .Include(x => x.Branch)
                .Include(x => x.City)
                .Where(x => x.Id == nashUserId && x.IsDeleted == false);
            
        }

        public NashUserViewModel FindOneMapped(int nashUserId) => 
            this.FindOne(nashUserId).FirstOrDefault<NashUser>().ToViewModel();

        public IList<GenderType> GetGenderTypes()
        {
            return NashContext.GenderTypes
                .Where(x => x.IsDeleted == false)
                .ToList();

          
        }

        public IList<NashRole> GetNashRoles()
        {
            return NashContext.NashRoles
                .Where(x => x.IsDeleted == false && x.Name != "Super Admin")
                .ToList();
        }



        public IList<NashUserType> GetNashUserType()
        {
            return NashContext.NashUserTypes
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

