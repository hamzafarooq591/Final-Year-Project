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
    public class B2BTransferServiceTests
    {



        [TestMethod()]
        public void CreateB2BTransferTest()
        {
            B2BTransferService B2BTransferService = new B2BTransferService();
            CompanyService companyService = new CompanyService();
            BranchService branchService = new BranchService();
            BankAccountService bankAccountService = new BankAccountService();
            B2BTransferBindingModel model = new B2BTransferBindingModel
            {
                ToBankAccountId = bankAccountService.GetBankAccount(1, 1).Data[0].BankAccountId,
                CompanyId = companyService.GetCompany(1, 1, "").Data[0].CompanyId,
                Amount = 78800,
                BankCharges = 990,
                BranchId = branchService.GetBranch(1, 1).Data[0].BranchId,
                TransferDate = DateTime.Now,
                TransferDescription = "Demand Draft",
                UploadProof = "Draft Image"
            };

            int userId = 1;
            var newuser = B2BTransferService.CreateB2BTransfer(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod]
        public void GetB2BTransferTest()
        {
            B2BTransferService B2BTransferService = new B2BTransferService();
            int rows = 10, pageNumber = 1;
            var accountList = B2BTransferService.GetB2BTransfer(rows: rows, pageNumber: pageNumber);
        }

        [TestMethod()]
        public void GetB2BTransferByB2BTransferId()
        {
            B2BTransferService B2BTransferService = new B2BTransferService();
            int B2BTransferId = 2;
            var B2BTransferById = B2BTransferService.GetB2BTransferByB2BTransferId(B2BTransferId);
        }

        [TestMethod()]
        public void DeleteB2BTransfer()
        {
            B2BTransferService B2BTransferService = new B2BTransferService();
            int B2BTransferId = B2BTransferService.GetB2BTransfer(1, 1).Data[0].B2BTransferId;
            var DeleteB2BTransfer = B2BTransferService.DeleteB2BTransfer(B2BTransferId);
        }

        [TestMethod()]
        public void UpdateB2BTransfer()
        {
            B2BTransferService B2BTransferService = new B2BTransferService();
            BankAccountService bankAccountService = new BankAccountService();
            CompanyService companyService = new CompanyService();
            BranchService branchService = new BranchService();

            B2BTransferBindingModel model = new B2BTransferBindingModel
            {
                B2BTransferId = 2,
                ToBankAccountId = bankAccountService.GetBankAccount(1, 1).Data[0].BankAccountId,
                CompanyId = companyService.GetCompany(1, 1, "").Data[0].CompanyId,
                Amount = 55000,
                BankCharges = 250,
                BranchId = branchService.GetBranch(1, 1).Data[0].BranchId,
                TransferDate = DateTime.Now,
                TransferDescription = "Changed Description",
                UploadProof = "Image String Changed"
            };
            int userId = 61;
            var UpdateB2BTransfer = B2BTransferService.UpdateB2BTransfer(model, userId);
        }
    }
}