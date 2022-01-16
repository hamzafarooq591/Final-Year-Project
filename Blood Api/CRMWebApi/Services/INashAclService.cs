namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System.Collections.Generic;

    public interface INashAclService
    {
        NashAclViewModel CreateNashAcl(NashAclBindingModel model, int userId);
        bool DeleteNashAcl(int NashAclId);
        NashAclViewModel GetNashAclByNashAclId(int NashAclId);
        NashPagedList<NashAclViewModel> GetNashAcls(int rows, int pageNumber);
        NashAclViewModel UpdateNashAcl(NashAclBindingModel model, int userId);

        List<NashAclViewModel> GetNashAclByNashUserId(int NashUserId);
    }
}

