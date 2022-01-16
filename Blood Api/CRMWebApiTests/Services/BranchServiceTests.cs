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
    public class BranchServiceTests
    {

        [TestMethod()]
        public void CreateCompanyTest()
        {
            CompanyService companyService = new CompanyService();
            CompanyBindingModel companyBindingModel = new CompanyBindingModel
            {
                Description = "Company Test Description",
                Name = "Test Company"
            };

            var NewCompany = companyService.CreateCompany(companyBindingModel, 1);

            Assert.IsNotNull(NewCompany);
        }

        [TestMethod()]
        public void CreateBranchTest()
        {
            BranchService BranchService = new BranchService();
            CompanyService companyService = new CompanyService();
            BranchBindingModel model = new BranchBindingModel
            {
                BranchDescription = "Branch in Society",
                BranchName = "Society",
                CompanyId = companyService.GetCompany(1, 1, "").Data[0].CompanyId
            };

            int userId = 1;
            var newuser = BranchService.CreateBranch(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod]
        public void GetBranchTest()
        {
            BranchService BranchService = new BranchService();
            var BranchList = BranchService.GetBranch(rows: 10, pageNumber: 1,CompanyId:21);
        }

        [TestMethod()]
        public void GetBranchByBranchId()
        {
            BranchService BranchService = new BranchService();
            int BranchId = 7;
            var BranchById = BranchService.GetBranchByBranchId(BranchId);
        }

        [TestMethod()]
        public void DeleteBranch()
        {
            BranchService BranchService = new BranchService();
            var DeleteBranch = BranchService.DeleteBranch(13);
        }

        [TestMethod()]
        public void UpdateBranch()
        {
            BranchService branchService = new BranchService();
            CompanyService companyService = new CompanyService();
            BranchBindingModel model = new BranchBindingModel
            {
                BranchId = 10,
                BranchDescription = "New Changed Branch",
                BranchName = "DGK Branch Changed",
                CompanyId = companyService.GetCompany(1,1,"").Data[0].CompanyId
            };
            int userId = 8;
            var BranchUpdate = branchService.UpdateBranch(model, userId);
        }
    }
}