using Microsoft.VisualStudio.TestTools.UnitTesting;
using NashWebApi.BindingModels;
using NashWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NashWebApi.ViewModels;

namespace NashWebApi.Services.Tests
{
    [TestClass()]
    public class AccountsHeadServiceTests
    {
        [TestMethod()]
        public void CreateAccountsHeadTest()
        {
            AccountsHeadService AccountsHeadService = new AccountsHeadService();
            AccountsHeadBindingModel model = new AccountsHeadBindingModel
            {
                AssetId = 10,
                EquityOrCapitalId = 10,
                ExpensesId = 10,
                IncomeOrRevenueId = 9,
                LiabilityId = 10
            };

            int userId = 1;
            var newuser = AccountsHeadService.CreateAccountsHead(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod]
        public void GetAccountsHeadTest()
        {
            AccountsHeadService accountsHeadService = new AccountsHeadService();
            int rows = 10, pageNumber = 1;
            var accountList = accountsHeadService.GetAccountsHead(rows: rows, pageNumber: pageNumber, SearchString: "");
        }

        [TestMethod()]
        public void GetAccountsHeadByAccountsHeadId()
        {
            AccountsHeadService accountsHeadService = new AccountsHeadService();
            int AccountsHeadId = 11;
            var AccountsHeadById = accountsHeadService.GetAccountsHeadByAccountsHeadId(AccountsHeadId);
        }

        [TestMethod()]
        public void DeleteAccountsHead()
        {
            AccountsHeadService accountsHeadService = new AccountsHeadService();
            int AccountsHeadId = accountsHeadService.GetAccountsHead(1,1,"").Data[0].AccountsHeadId;
            var DeleteAccountsHead = accountsHeadService.DeleteAccountsHead(AccountsHeadId);
        }

        [TestMethod()]
        public void UpdateAccountsHead()
        {
            AccountsHeadService accountsHeadService = new AccountsHeadService();

            AccountsHeadBindingModel model = new AccountsHeadBindingModel
            {
                AccountsHeadId = 2,
                AssetId = 12,
                EquityOrCapitalId = 9,
                ExpensesId = 10,
                LiabilityId = 9,
                IncomeOrRevenueId = 11
            };
            int userId = 8;
            var UpdateAccountsHead = accountsHeadService.UpdateAccountsHead(model, userId);
        }
    }
}