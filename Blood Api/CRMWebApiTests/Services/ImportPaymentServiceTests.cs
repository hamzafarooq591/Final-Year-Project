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
    public class ImportPaymentServiceTests
    {



        //[TestMethod()]
        //public void CreateImportPaymentTest()
        //{
        //    ImportPaymentService ImportPaymentService = new ImportPaymentService();
        //    //CompanyService companyService = new CompanyService();
        //    ImportPaymentBindingModel model = new ImportPaymentBindingModel
        //    {
        //        Amount = 54111155,
        //        //BankAccountId = 0,
        //        CompanyId = 20,
        //        BankCharges = 788,
        //        Comments = "TEst",
        //        ConfirmationDate = DateTime.Now.ToString(),
        //        ConfirmationProof = "Some",
        //        CurrencyId = 4,
        //        ExchangeRate = 343,
        //        //ImportPaymentId = 1,
        //        MoneyChangerId = 2,
        //        OtherAmount = 677,
        //        OtherAmountDescription = "Description",
        //        PaymentTypeId = 1,
        //        PayToId = 1,
        //        PayToTypeId = 1,
        //        TransferAmount = 677,
        //        TransferDate = DateTime.Now.ToString()
        //    };

        //    int userId = 1;
        //    var newuser = ImportPaymentService.CreateImportPayment(model: model, userId: userId);

        //    Assert.IsNotNull(newuser);
        //}

        [TestMethod]
        public void GetImprotTest()
        {
            ImportPaymentService importPaymentService = new ImportPaymentService();
            var ImportList = importPaymentService.GetImportPayment(rows: 10, pageNumber: 1, PayToType:2);
        }

        //[TestMethod()]
        //public void GetPaymentByPaytoTypeId()
        //{
        //    ImportPaymentService importPaymentService = new ImportPaymentService();
        //    int importId = 18;
        //    var importById = importPaymentService.GetImportPaymentByImportPaymentId(importId);
        //}

        //    [TestMethod()]
        //    public void DeleteBranch()
        //    {
        //        BranchService BranchService = new BranchService();
        //        var DeleteBranch = BranchService.DeleteBranch(13);
        //    }

        //    [TestMethod()]
        //    public void UpdateBranch()
        //    {
        //        BranchService branchService = new BranchService();
        //        CompanyService companyService = new CompanyService();
        //        BranchBindingModel model = new BranchBindingModel
        //        {
        //            BranchId = 10,
        //            BranchDescription = "New Changed Branch",
        //            BranchName = "DGK Branch Changed",
        //            CompanyId = companyService.GetCompany(1,1,"").Data[0].CompanyId
        //        };
        //        int userId = 8;
        //        var BranchUpdate = branchService.UpdateBranch(model, userId);
        //    }
    }
}