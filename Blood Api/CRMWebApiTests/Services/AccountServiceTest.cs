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
    public class AccountServiceTests
    {



        //    [TestMethod()]
        //    public void CreateAccountTest()
        //    {
        //        AccountService AccountService = new AccountService();
        //        BranchService branchService = new BranchService();
        //        AccountBindingModel model = new AccountBindingModel
        //        {
        //            AccountName = "Rent",
        //            AccountDescription = "Rent for Establishment Buildings",
        //            ParentAccountId = 17,
        //            BranchId = branchService.GetBranch(1, 1).Data[0].BranchId,
        //        };

        //        int userId = 1;
        //        var newuser = AccountService.CreateAccount(model: model, userId: userId);

        //        Assert.IsNotNull(newuser);
        //    }

        //    [TestMethod]
        //    public void GetAccountTest()
        //    {
        //        AccountService accountService = new AccountService();
        //        var accountList = accountService.GetAccount(rows: 10, pageNumber: 1, BranchId: 11);
        //    }

        //    [TestMethod()]
        //    public void GetAccountByAccountId()
        //    {
        //        AccountService accountService = new AccountService();
        //        int AccountId = 11;
        //        var AccountById = accountService.GetAccountByAccountId(AccountId);
        //    }

        [TestMethod()]
        public void DeleteAccount()
        {
            AccountService accountService = new AccountService();
            var AccountById = accountService.DeleteAccount(38);
        }

        //    [TestMethod()]
        //    public void UpdateAccount()
        //    {
        //        AccountService accountService = new AccountService();
        //        BranchService branchService = new BranchService();
        //        AccountBindingModel model = new AccountBindingModel
        //        {
        //            AccountId = 13,
        //            AccountName = "Account1 Changed",
        //            AccountDescription = "Account1 changed to ISB",
        //            ParentAccountId = accountService.GetAccount(1, 1).Data[0].AccountId,
        //            BranchId = branchService.GetBranch(1, 1).Data[0].BranchId,
        //        };
        //        int userId = 8;
        //        var AccountById = accountService.UpdateAccount(model, userId);
        //    }

        //    [TestMethod()]
        //    public void GetTrailBalance()
        //    {
        //        AccountService accountService = new AccountService();
        //        int page = 1, row = 10;
        //        var TrailBalance = accountService.GetTrailBalance(rows: row, pageNumber: page, SearchString: "");
        //    }

        //    [TestMethod]
        //    public void GetChartOfAccount()
        //    {
        //        AccountService accountService = new AccountService();
        //        int rows = 10, pageNumber = 1;
        //        var ChartOfAccountList = accountService.GetAccount(rows: rows, pageNumber: pageNumber);
        //    }

        //    [TestMethod]
        //    public void GetParentAccountTest()
        //    {
        //        AccountService accountService = new AccountService();
        //        int rows = 10, pageNumber = 1;
        //        var parentAccountList = accountService.GetParentAccount(rows: rows, pageNumber: pageNumber);
        //    }
        //    [TestMethod]
        //    public void GetProfitAndLoss()
        //    {
        //        AccountService accountService = new AccountService();
        //        var account = accountService.GetProfitAndLoss();
        //    }
    }
}