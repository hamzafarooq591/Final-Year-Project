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
    public class BankAccountServiceTests
    {



        [TestMethod()]
        public void CreateBankAccountTest()
        {
            BankAccountService BankAccountService = new BankAccountService();
            BankAccountBindingModel model = new BankAccountBindingModel
            {
                AccountTitle = "Saqlain",
                AccountNumber = "AXN2088-189078-11",
                BankId = 1,
                BranchCode = "LHR208",
                CompanyId = 4,
                OpeningBalance = 7095000
            };

            int userId = 1;
            var newuser = BankAccountService.CreateBankAccount(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }
        [TestMethod()]
        public void GetBankAccountTest()
        {
            BankAccountService bankAccountService = new BankAccountService();
            var BankAccountList = bankAccountService.GetBankAccount(10, 1);
            BankAccountList.Data.ToList();
        }
        [TestMethod()]
        public void GetBankAccountByBankAccountId()
        {
            BankAccountService BankAccountService = new BankAccountService();
            int BankAccountId = 7;
            var BankAccountById = BankAccountService.GetBankAccountByBankAccountId(BankAccountId);
        }

        [TestMethod()]
        public void DeleteBankAccount()
        {
            BankAccountService BankAccountService = new BankAccountService();
            int BankAccountId = BankAccountService.GetBankAccount(1, 1).Data[0].BankAccountId;
            var DeleteBankAccount = BankAccountService.DeleteBankAccount(BankAccountId);
        }

        [TestMethod()]
        public void UpdateBankAccount()
        {
            BankAccountService BankAccountService = new BankAccountService();

            BankAccountBindingModel model = new BankAccountBindingModel
            {
                BankAccountId = 8,
                AccountTitle = "New BankAccount1",
                AccountNumber = "AXR2099-333211-2-001",
                BankId = 1,
                BranchCode = "MUL209",
                CompanyId = 4,
                OpeningBalance = 405000
            };
            int userId = 61;
            var UpdateBankAccount = BankAccountService.UpdateBankAccount(model, userId);
        }
    }
}