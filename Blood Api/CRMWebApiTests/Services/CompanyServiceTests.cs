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
    public class CompanyServiceTests
    {



        [TestMethod()]
        public void CreateCompanyTest()
        {
            CompanyService CompanyService = new CompanyService();
            CompanyBindingModel model = new CompanyBindingModel
            {
                Name = "Dgk CC",
                Description = "DGK Cement Company",
                CompanyImageUpload = "ABCXYZ2"
            };

            int userId = 1;
            var newuser = CompanyService.CreateCompany(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod()]
        public void GetCompanyTest()
        {
            CompanyService companyService = new CompanyService();
            int rows = 10, pageNumber = 1;
            var CompanyList = companyService.GetCompany(rows: rows, pageNumber: pageNumber, SearchString: "");
        }

        [TestMethod()]
        public void GetCompanyByCompanyId()
        {
            CompanyService companyService = new CompanyService();
            int CompanyId = companyService.GetCompany(1, 1, "").Data[0].CompanyId;
            var CompanyListById = companyService.GetCompanyByCompanyId(CompanyId);
        }

        [TestMethod()]
        public void DeleteCompany()
        {
            CompanyService companyService = new CompanyService();
            var DeleteCompany = companyService.DeleteCompany(3);
        }

        [TestMethod()]
        public void UpdateCompany()
        {
            CompanyService CompanyService = new CompanyService();
            BranchService branchService = new BranchService();
            CompanyBindingModel model = new CompanyBindingModel
            {
                CompanyId = 13,
                Name = "Company1 Changed",
                Description = "Company1 changed to ISB",
                CompanyImageUpload = ""
            };
            int userId = 8;
            var CompanyById = CompanyService.UpdateCompany(model, userId);
        }

    }
}