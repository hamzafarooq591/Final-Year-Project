using Microsoft.VisualStudio.TestTools.UnitTesting;
using NashWebApi.BindingModels;
using NashWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashWebApi.Services.Tests
{
    [TestClass()]
    public class NashUserServiceTests
    {




        [TestMethod()]
        public void CreateNashUserTypeTest()
        {
            NashUserService nashUserService = new NashUserService();

            NashUserTypeBindingModel model = new NashUserTypeBindingModel
            {
                Description = "Internal",
                Name = "Internal"

            };

            nashUserService.CreateNashUserType(model, 1);
        }



        [TestMethod()]
        public void CreateNashUserTest()
        {
            NashUserService nashUserService = new NashUserService();
            BranchService branchService = new BranchService();


            NashUserBindingModel model = new NashUserBindingModel
            {
                Email = "email@domain.com",
                FirstName = "first_name",
                LastName = "last_name",
                NashUserTypeId = nashUserService.GetNashUserTypes().FirstOrDefault<Entities.NashUserType>().Id,
                Password = "pass",
                BranchId = branchService.GetBranch(1, 1).Data[0].BranchId,
                UserName = "email@domain.com"
            };

            int userId = 1;
            var newuser = nashUserService.CreateNashUser(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod()]
        public void GetNashUserTypesTest()
        {
            NashUserService nashUserService = new NashUserService();
           var NashUserTypeList = nashUserService.GetNashUserTypes();
        }
    }
}