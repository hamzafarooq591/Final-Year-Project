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
    public class ApprovalServiceTests
    {



        [TestMethod()]
        public void CreateApprovalTest()
        {
            ApprovalService ApprovalService = new ApprovalService();
            ApprovalBindingModel model = new ApprovalBindingModel
            {
                ApprovalTitle = "Approved",
                ApprovalDescription = "Task Approved"
            };

            int userId = 1;
            var newuser = ApprovalService.CreateApproval(model: model, userId: userId);

            Assert.IsNotNull(newuser);
        }

        [TestMethod]
        public void GetApprovalTest()
        {
            ApprovalService ApprovalService = new ApprovalService();
            int rows = 10, pageNumber = 1;
            var accountList = ApprovalService.GetApproval(rows: rows, pageNumber: pageNumber);
        }

        [TestMethod()]
        public void GetApprovalByApprovalId()
        {
            ApprovalService ApprovalService = new ApprovalService();
            int ApprovalId = 4;
            var ApprovalById = ApprovalService.GetApprovalByApprovalId(ApprovalId);
        }

        [TestMethod()]
        public void DeleteApproval()
        {
            ApprovalService ApprovalService = new ApprovalService();
            int ApprovalId = ApprovalService.GetApproval(1, 1).Data[0].ApprovalId;
            var DeleteApproval = ApprovalService.DeleteApproval(ApprovalId);
        }

        [TestMethod()]
        public void UpdateApproval()
        {
            ApprovalService ApprovalService = new ApprovalService();

            ApprovalBindingModel model = new ApprovalBindingModel
            {
                ApprovalId = 5,
                ApprovalDescription = "Approved by Admin",
                ApprovalTitle = "Approved",
            };
            int userId = 61;
            var UpdateApproval = ApprovalService.UpdateApproval(model, userId);
        }
    }
}