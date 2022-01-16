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
    public class TransactionServiceTests
    {
        [TestMethod()]
        public void CreateTransactionListTest()
        {
            TransactionService TransactionService = new TransactionService();
            AccountService accountService = new AccountService();
            TransactionBindingModel model1 = new TransactionBindingModel
            {
                TransactionDescription = "A1 Trans",
                Amount = 33240,
                TransactionType = true,
                AccountId = accountService.GetAccount(1, 1).Data[0].AccountId,
            };
            TransactionBindingModel model2 = new TransactionBindingModel
            {
                TransactionDescription = "A2 Trans",
                Amount = 30900,
                TransactionType = false,
                AccountId = accountService.GetAccount(1, 1).Data[0].AccountId,
            };

            List < TransactionBindingModel> models = new List<TransactionBindingModel>();
            models.Add(model1);
            models.Add(model2);
            
            int userId = 1;
            var newuser = TransactionService.CreateTransactionList(models: models, userId: userId);

            Assert.IsNotNull(newuser);
        }

        //        [TestMethod()]
        //        public void CreateTransactionTest()
        //        {
        //            TransactionService TransactionService = new TransactionService();
        //            AccountService accountService = new AccountService();
        //            TransactionBindingModel model = new TransactionBindingModel
        //            {
        //                TransactionDescription = "New Transaction1",
        //                Amount = 45000,
        //                TransactionType = true,
        //                AccountId = accountService.GetAccount(1, 1).Data[0].AccountId,
        //            };

        //            int userId = 1;
        //            var newuser = TransactionService.CreateTransaction(model: model, userId: userId);

        //            Assert.IsNotNull(newuser);
        //        }

        //        [TestMethod]
        //        public void GetTransactionTest()
        //        {
        //            TransactionService transactionService = new TransactionService();
        //            var TransactionList = transactionService.GetTransaction(rows: 10, pageNumber: 1);
        //        }

        //        [TestMethod]
        //        public void GetTransactionByTransactionIdTest()
        //        {
        //            TransactionService transactionService = new TransactionService();
        //            int transactionId =0 ;
        //            var TransactionById = transactionService.GetTransactionByTransactionId(transactionId);
        //        }

        //        [TestMethod()]
        //        public void DeleteTransaction()
        //        {
        //            TransactionService transactionService = new TransactionService();
        //            int TransactionId = 0;
        //            var Transaction = transactionService.DeleteTransaction(TransactionId);
        //        }
        //        [TestMethod]
        //        public void GetAccountLedger()
        //        {
        //            TransactionService transactionService = new TransactionService();
        //            AccountService accountService = new AccountService();
        //            int AccountId = 10;
        //            int page = 1, row = 10;
        //            var Transaction = transactionService.GetTransactionByAccountId(rows: row, pageNumber: page, accountId:AccountId);
        //        }
    }
}