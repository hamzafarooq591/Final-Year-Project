namespace NashWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountDescription = c.String(),
                        AccountName = c.String(),
                        ParentAccountId = c.Int(),
                        AccountHeadId = c.Int(),
                        BranchId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Accounts", t => t.ParentAccountId)
                .Index(t => t.ParentAccountId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchDescription = c.String(),
                        BranchName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.NashCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        ImageId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageUploads", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ImageUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        fileUrl = c.String(),
                        Title = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountsHeads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        LiabilityId = c.Int(nullable: false),
                        IncomeOrRevenueId = c.Int(nullable: false),
                        ExpensesId = c.Int(nullable: false),
                        EquityOrCapitalId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AssetId)
                .ForeignKey("dbo.Accounts", t => t.EquityOrCapitalId)
                .ForeignKey("dbo.Accounts", t => t.ExpensesId)
                .ForeignKey("dbo.Accounts", t => t.IncomeOrRevenueId)
                .ForeignKey("dbo.Accounts", t => t.LiabilityId)
                .Index(t => t.AssetId)
                .Index(t => t.LiabilityId)
                .Index(t => t.IncomeOrRevenueId)
                .Index(t => t.ExpensesId)
                .Index(t => t.EquityOrCapitalId);
            
            CreateTable(
                "dbo.AdvanceSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvanceSalaryDate = c.DateTime(nullable: false),
                        AdvanceAmount = c.Single(nullable: false),
                        Comments = c.String(),
                        BankAccountId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .Index(t => t.BankAccountId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountTitle = c.String(),
                        AccountNumber = c.String(),
                        BranchCode = c.String(),
                        OpeningBalance = c.Single(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        BankAddress = c.String(),
                        BankPhoneNo = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        EmployeeFName = c.String(),
                        EmployeeLName = c.String(),
                        DesignationId = c.Int(nullable: false),
                        EmployeeCode = c.String(),
                        EmployeeJoiningDate = c.DateTime(),
                        EmployeeBasicSalary = c.Single(nullable: false),
                        EmployeeConveyanceAllowance = c.Single(nullable: false),
                        EmployeeHouseRent = c.Single(nullable: false),
                        EmployeeMedicalAllowance = c.Single(nullable: false),
                        EmployeeEducationAllowance = c.Single(nullable: false),
                        EmployeeMobileAllowance = c.Single(nullable: false),
                        BankName = c.String(),
                        AccountNumber = c.String(),
                        MobileNumber = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.BranchId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationDescription = c.String(),
                        DesignationName = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        OfferId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .ForeignKey("dbo.Offers", t => t.OfferId)
                .Index(t => t.AppointmentId)
                .Index(t => t.OfferId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Addres = c.String(),
                        City = c.String(),
                        AppointmentDateTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                        TotalAmount = c.Double(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        OldPrice = c.Double(nullable: false),
                        NewPrice = c.Double(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentTestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        AppointmentTestId = c.Int(nullable: false),
                        AppointmenttestResultFile = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .ForeignKey("dbo.AppointmentTests", t => t.AppointmentTestId)
                .Index(t => t.AppointmentId)
                .Index(t => t.AppointmentTestId);
            
            CreateTable(
                "dbo.AppointmentTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.AppointmentId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Approvals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApprovalDescription = c.String(),
                        ApprovalTitle = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.B2BTransfer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        FromBankAccountId = c.Int(nullable: false),
                        ToBankAccountId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        BankCharges = c.Single(nullable: false),
                        TransferDate = c.DateTime(nullable: false),
                        TransferDescription = c.String(),
                        UploadProof = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.BankAccounts", t => t.FromBankAccountId)
                .ForeignKey("dbo.BankAccounts", t => t.ToBankAccountId)
                .Index(t => t.BranchId)
                .Index(t => t.FromBankAccountId)
                .Index(t => t.ToBankAccountId);
            
            CreateTable(
                "dbo.BillToTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryDescription = c.String(),
                        CategoryName = c.String(),
                        ImageId = c.Int(nullable: false),
                        IsShowOnHomePage = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageUploads", t => t.ImageId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .Index(t => t.ImageId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ManufacturerName = c.String(),
                        ImageId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageUploads", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityCode = c.String(),
                        CityName = c.String(),
                        GeoLocationId = c.Int(nullable: false),
                        phoneCode = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeoLocations", t => t.GeoLocationId)
                .Index(t => t.GeoLocationId);
            
            CreateTable(
                "dbo.GeoLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        Currency = c.String(),
                        CurrencyCode = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClearingAgents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        CAName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        FaxNo = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanySettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MundRateInKG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourierCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourierCompanyName = c.String(),
                        CourierCompanyNumber = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarrantyOrRepairRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        MacAddress = c.String(),
                        ProblemType = c.String(),
                        Comments = c.String(),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        WarrantyStatusId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.WarrantyRequestStatus", t => t.WarrantyStatusId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.WarrantyStatusId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerPhoneNo = c.String(),
                        CustomerCompanyName = c.String(),
                        isTransporter = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductShortDescription = c.String(),
                        ProductLongDescription = c.String(),
                        ProductName = c.String(),
                        OldPrice = c.String(),
                        SpecialPrice = c.String(),
                        SpecialPriceStartDate = c.DateTime(nullable: false),
                        SpecialPriceEndDate = c.DateTime(nullable: false),
                        IsShowOnHomePage = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        IsFeaturedProduct = c.Boolean(nullable: false),
                        AllowCustomerReviews = c.Boolean(nullable: false),
                        DisableBuyButton = c.Boolean(nullable: false),
                        MacAddressRequired = c.Boolean(nullable: false),
                        WarrantyModeId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId)
                .ForeignKey("dbo.WarrantyModes", t => t.WarrantyModeId)
                .Index(t => t.WarrantyModeId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.WarrantyModes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarrantyModePeriod = c.String(),
                        WarrantyModePeriodInDays = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarrantyRequestStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(),
                        StatusTitle = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                        CurrencyTitle = c.String(),
                        CurrencySymbol = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DcGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DcGroupDescription = c.String(),
                        DcGroupTitle = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DcSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        DcSummaryDate = c.DateTime(nullable: false),
                        Transfered = c.Int(nullable: false),
                        Received = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.DcGroups", t => t.GroupId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.EmailAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderEmailAddress = c.String(),
                        SenderName = c.String(),
                        HostAddress = c.String(),
                        HostPortNumber = c.String(),
                        HostUserName = c.String(),
                        HostPassword = c.String(),
                        IsSSL = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailSMSTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailSubject = c.String(),
                        EmailTemplate = c.String(),
                        EmailTemplateTypeId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailTemplateTypes", t => t.EmailTemplateTypeId)
                .Index(t => t.EmailTemplateTypeId);
            
            CreateTable(
                "dbo.EmailTemplateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateType = c.String(),
                        TemplateDescription = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeBonus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusMonth = c.DateTime(nullable: false),
                        BonusOccasion = c.String(),
                        BonusAmount = c.Single(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeLoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanAmount = c.Single(nullable: false),
                        ApprovalId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approvals", t => t.ApprovalId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.ApprovalId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.FreightForwarders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        FFName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        FaxNo = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.GenderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomePageSlides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        PictureURL = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        SlideImageId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageUploads", t => t.SlideImageId)
                .Index(t => t.SlideImageId);
            
            CreateTable(
                "dbo.ImportPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        CurrencyId = c.Int(),
                        BankAccountId = c.Int(),
                        PaymentTypeId = c.Int(nullable: false),
                        PayToTypeId = c.Int(nullable: false),
                        MoneyChangerId = c.Int(),
                        ChequeNo = c.String(),
                        PayToId = c.Int(nullable: false),
                        ExchangeRate = c.Single(nullable: false),
                        TransferAmount = c.Single(nullable: false),
                        TransferDate = c.DateTime(),
                        BankCharges = c.Single(nullable: false),
                        ConfirmationDate = c.DateTime(nullable: false),
                        ConfirmationProof = c.String(),
                        Comments = c.String(),
                        Amount = c.Single(nullable: false),
                        OtherAmount = c.Single(nullable: false),
                        OtherAmountDescription = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.MoneyChangers", t => t.MoneyChangerId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.PayToTypes", t => t.PayToTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.CurrencyId)
                .Index(t => t.BankAccountId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.PayToTypeId)
                .Index(t => t.MoneyChangerId);
            
            CreateTable(
                "dbo.MoneyChangers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MCAccountId = c.Int(nullable: false),
                        MCName = c.String(),
                        MCEmail = c.String(),
                        MobileNo = c.String(),
                        TelNo = c.String(),
                        FaxNo = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.MCAccountId)
                .Index(t => t.MCAccountId);
            
            CreateTable(
                "dbo.PayToTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        RequestQuantity = c.Int(nullable: false),
                        Comments = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.InventoryStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                        Returned = c.Int(nullable: false),
                        Missing = c.Int(nullable: false),
                        Defected = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        InvoiceMasterId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceMasters", t => t.InvoiceMasterId)
                .Index(t => t.InvoiceMasterId);
            
            CreateTable(
                "dbo.InvoiceMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        InvoiceDate = c.DateTime(nullable: false),
                        TotalAmount = c.Single(nullable: false),
                        SaleTax = c.Single(nullable: false),
                        GrandTotal = c.Single(nullable: false),
                        PayOrderNumber = c.String(),
                        BillToTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        ImageUploadId = c.Int(),
                        BillToId = c.Int(nullable: false),
                        Comments = c.String(),
                        CompanyNameTitle = c.String(),
                        InvoiceTitle = c.String(),
                        Subject = c.String(),
                        Para01 = c.String(),
                        Para02 = c.String(),
                        EquipmentWarranty = c.String(),
                        Validity = c.String(),
                        Taxes = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillToTypes", t => t.BillToTypeId)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .ForeignKey("dbo.ImageUploads", t => t.ImageUploadId)
                .Index(t => t.BillToTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.ImageUploadId);
            
            CreateTable(
                "dbo.InvoiceSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalBilled = c.Int(nullable: false),
                        TotalPaid = c.Int(nullable: false),
                        TotalPending = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        Rate = c.String(),
                        QuantityWeightKG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MilingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackagingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MissingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ItemDate = c.DateTime(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        Comments = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.NashAcls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAddAllowed = c.Boolean(nullable: false),
                        IsDeleteAllowed = c.Boolean(nullable: false),
                        IsEditAllowed = c.Boolean(nullable: false),
                        isViewAllowed = c.Boolean(nullable: false),
                        PageId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashPages", t => t.PageId)
                .ForeignKey("dbo.NashRoles", t => t.RoleId)
                .Index(t => t.PageId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.NashPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ParentPageId = c.Int(),
                        Title = c.String(),
                        Url = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashPages", t => t.ParentPageId)
                .Index(t => t.ParentPageId);
            
            CreateTable(
                "dbo.NashRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        RoleDisplayId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NashUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NashRoleId = c.Int(nullable: false),
                        NashUserId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashRoles", t => t.NashRoleId)
                .ForeignKey("dbo.NashUsers", t => t.NashUserId)
                .Index(t => t.NashRoleId)
                .Index(t => t.NashUserId);
            
            CreateTable(
                "dbo.NashUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Bio = c.String(),
                        CityId = c.Int(),
                        ContactImageUrl = c.String(),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(),
                        FirstName = c.String(),
                        BranchId = c.Int(),
                        GenderId = c.Int(),
                        IsFeatured = c.Boolean(nullable: false),
                        LastName = c.String(),
                        latitute = c.String(),
                        longitude = c.String(),
                        NashUserTypeId = c.Int(nullable: false),
                        password = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                        WebsiteUrl = c.String(),
                        Zipcode = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.GenderTypes", t => t.GenderId)
                .ForeignKey("dbo.NashUserTypes", t => t.NashUserTypeId)
                .Index(t => t.CityId)
                .Index(t => t.BranchId)
                .Index(t => t.GenderId)
                .Index(t => t.NashUserTypeId);
            
            CreateTable(
                "dbo.NashUserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NashUserSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NashUserId = c.Int(nullable: false),
                        IsExpired = c.Boolean(nullable: false),
                        SessionDuration = c.Int(nullable: false),
                        SessionKey = c.String(),
                        SessionStart = c.DateTime(),
                        SessionEnd = c.DateTime(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashUsers", t => t.NashUserId)
                .Index(t => t.NashUserId);
            
            CreateTable(
                "dbo.NewsConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        NewsToDisplay = c.Int(nullable: false),
                        NewsArchivePageSize = c.Int(nullable: false),
                        UnregisteredComments = c.Boolean(nullable: false),
                        RSSFeedsLink = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLetters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsLetterSubject = c.String(),
                        NewsLetterBody = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLetterSubscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NashUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashUsers", t => t.NashUserId)
                .Index(t => t.NashUserId);
            
            CreateTable(
                "dbo.NewsLetterTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsSubject = c.String(),
                        NewsTemplate = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsListTitle = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProductWarranties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MacAddress = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderPlacementDate = c.DateTime(nullable: false),
                        OrderQuantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        NashUserId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approvals", t => t.OrderStatusId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.InvoiceMasters", t => t.InvoiceId)
                .ForeignKey("dbo.NashUsers", t => t.NashUserId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.NashUserId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.OtherPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        BranchId = c.Int(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        ClearingDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CheqOrRefNo = c.String(),
                        Amount = c.Single(nullable: false),
                        Comments = c.String(),
                        ImageProofId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approvals", t => t.StatusId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.ImageUploads", t => t.ImageProofId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .Index(t => t.BranchId)
                .Index(t => t.BankAccountId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.ImageProofId);
            
            CreateTable(
                "dbo.PageContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaticPageId = c.Int(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        IsIncludedSiteMap = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaticPages", t => t.StaticPageId)
                .Index(t => t.StaticPageId);
            
            CreateTable(
                "dbo.StaticPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaticPageDescription = c.String(),
                        StaticPageName = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsVerified = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        VerificationCode = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BankAccountId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        PayToTypeId = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        CheqOrRefNo = c.String(),
                        ClearingDate = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comments = c.String(),
                        SendSMS = c.Boolean(nullable: false),
                        PaymentStatusId = c.Int(nullable: false),
                        ImageProofId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.ImageUploads", t => t.ImageProofId)
                .ForeignKey("dbo.Approvals", t => t.PaymentStatusId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.PayToTypes", t => t.PayToTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.BankAccountId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.PayToTypeId)
                .Index(t => t.PaymentStatusId)
                .Index(t => t.ImageProofId);
            
            CreateTable(
                "dbo.Payslips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayMonth = c.String(),
                        EmployeeId = c.Int(),
                        ApprovalId = c.Int(),
                        PaidAmount = c.Single(nullable: false),
                        PayDate = c.DateTime(),
                        EmployeeBonusAmount = c.Single(nullable: false),
                        EmployeeBasicSalary = c.Single(nullable: false),
                        EmployeeTotalAllownces = c.Single(nullable: false),
                        AdvanceSalaryAmount = c.Single(nullable: false),
                        EmployeeLoanAmount = c.Single(nullable: false),
                        AbsentAmount = c.Single(nullable: false),
                        OtherDeductionAmount = c.Single(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approvals", t => t.ApprovalId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ApprovalId);
            
            CreateTable(
                "dbo.PerformaInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyNameTitle = c.String(),
                        InvoiceTitle = c.String(),
                        Subject = c.String(),
                        Para01 = c.String(),
                        Para02 = c.String(),
                        EquipmentWarranty = c.String(),
                        Validity = c.String(),
                        Taxes = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.ImageUploads", t => t.ImageId)
                .Index(t => t.ProductId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.ProductInStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.NashUsers", t => t.PersonId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.ProductWarranties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarrantyModeId = c.Int(nullable: false),
                        SerialMAC = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.WarrantyModes", t => t.WarrantyModeId)
                .Index(t => t.ProductId)
                .Index(t => t.WarrantyModeId);
            
            CreateTable(
                "dbo.PurchaseDeliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDeliveryDate = c.DateTime(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                        SaleDeliveryId = c.Int(nullable: false),
                        PurchaseBookingRateMund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .ForeignKey("dbo.SaleDeliveries", t => t.SaleDeliveryId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.SaleDeliveryId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RateInKG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityinWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReminingWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isCompleted = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Customers", t => t.PartyId)
                .Index(t => t.ItemId)
                .Index(t => t.PartyId);
            
            CreateTable(
                "dbo.SaleDeliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDeliveryDate = c.DateTime(nullable: false),
                        SellOrderId = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(nullable: false),
                        InsuranceCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransportCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransporterId = c.Int(),
                        VehicleNumber = c.String(),
                        isXMILL = c.Boolean(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .ForeignKey("dbo.SellOrders", t => t.SellOrderId)
                .ForeignKey("dbo.Customers", t => t.TransporterId)
                .Index(t => t.SellOrderId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.TransporterId);
            
            CreateTable(
                "dbo.SellOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sellDate = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                        PartyId = c.Int(nullable: false),
                        PurchaseOrderId = c.Int(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityinWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReminingWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isCompleted = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Customers", t => t.PartyId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.ItemId)
                .Index(t => t.PartyId)
                .Index(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.PurchaseDeliveryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        ItemName = c.String(),
                        ItemRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDeliveryId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.PurchaseDeliveries", t => t.PurchaseDeliveryId)
                .Index(t => t.ItemId)
                .Index(t => t.PurchaseDeliveryId);
            
            CreateTable(
                "dbo.ReturnProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReturnQuantity = c.Int(nullable: false),
                        ReturnProductDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.SaleDeliveryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        ItemName = c.String(),
                        ItemWeightKG = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ItemRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleDeliveryId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.SaleDeliveries", t => t.SaleDeliveryId)
                .Index(t => t.ItemId)
                .Index(t => t.SaleDeliveryId);
            
            CreateTable(
                "dbo.SiteSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageTitleSeparator = c.String(),
                        DefaultTitle = c.String(),
                        DefaultMetaKeyword = c.String(),
                        DefaultMetaDescription = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmsConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SmsTypeId = c.Int(nullable: false),
                        URL = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        DeviceName = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SmsTypes", t => t.SmsTypeId)
                .Index(t => t.SmsTypeId);
            
            CreateTable(
                "dbo.SmsTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SmsTypeDescription = c.String(),
                        SmsTypeTitle = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDescription = c.String(),
                        Amount = c.Single(nullable: false),
                        TransactionType = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                        RelatedEntityId = c.Int(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.VendorPODetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorPurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitCostUSD = c.Single(nullable: false),
                        TotalCostCFRUSD = c.Single(nullable: false),
                        LandingChargesUSD = c.Single(nullable: false),
                        InsuranceChargesUSD = c.Single(nullable: false),
                        OtherChargesUSD = c.Single(nullable: false),
                        ImportValueUSD = c.Single(nullable: false),
                        ImportValuePKR = c.Single(nullable: false),
                        CustomDutiesPKR = c.Single(nullable: false),
                        SalesTaxPKR = c.Single(nullable: false),
                        AddSalesTaxPKR = c.Single(nullable: false),
                        IncomeTaxPKR = c.Single(nullable: false),
                        TotalDutiesPKR = c.Single(nullable: false),
                        PenaltyCharges = c.Single(nullable: false),
                        CESS = c.Single(nullable: false),
                        CustomMisc = c.Single(nullable: false),
                        Wharfage = c.Single(nullable: false),
                        DOCharges = c.Single(nullable: false),
                        FreightCharges = c.Single(nullable: false),
                        ClearingCharges = c.Single(nullable: false),
                        OtherCharges = c.Single(nullable: false),
                        TotalCostPKR = c.Single(nullable: false),
                        UnitCostPKR = c.Single(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.VendorPurchaseOrders", t => t.VendorPurchaseOrderId)
                .Index(t => t.VendorPurchaseOrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.VendorPurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        PayOrderDate = c.DateTime(nullable: false),
                        PONumber = c.String(),
                        SupplierInvoiceNo = c.String(),
                        ExchangeRate = c.Single(nullable: false),
                        ImageUploadId = c.Int(nullable: false),
                        comments = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .ForeignKey("dbo.ImageUploads", t => t.ImageUploadId)
                .ForeignKey("dbo.Vendors", t => t.VendorId)
                .Index(t => t.CompanyId)
                .Index(t => t.VendorId)
                .Index(t => t.ImageUploadId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        POCode = c.String(),
                        VendorName = c.String(),
                        Email = c.String(),
                        MobileNo = c.String(),
                        FaxNo = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NashCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(),
                        Description = c.String(),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warranties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        SerialMAC = c.String(),
                        ReplacementSerialMAC = c.String(),
                        WarrantyModeId = c.Int(nullable: false),
                        WarrantyStartDate = c.DateTime(nullable: false),
                        WarrantyEndDate = c.DateTime(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.WarrantyModes", t => t.WarrantyModeId)
                .Index(t => t.OrderId)
                .Index(t => t.WarrantyModeId);
            
            CreateTable(
                "dbo.WPQuantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedByUserId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifiedByUserId = c.Int(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WPQuantities", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WPQuantities", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Warranties", "WarrantyModeId", "dbo.WarrantyModes");
            DropForeignKey("dbo.Warranties", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.VendorPODetails", "VendorPurchaseOrderId", "dbo.VendorPurchaseOrders");
            DropForeignKey("dbo.VendorPurchaseOrders", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.VendorPurchaseOrders", "ImageUploadId", "dbo.ImageUploads");
            DropForeignKey("dbo.VendorPurchaseOrders", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.VendorPODetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.SmsConfigurations", "SmsTypeId", "dbo.SmsTypes");
            DropForeignKey("dbo.SaleDeliveryItems", "SaleDeliveryId", "dbo.SaleDeliveries");
            DropForeignKey("dbo.SaleDeliveryItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ReturnProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ReturnProducts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseDeliveryItems", "PurchaseDeliveryId", "dbo.PurchaseDeliveries");
            DropForeignKey("dbo.PurchaseDeliveryItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PurchaseDeliveries", "SaleDeliveryId", "dbo.SaleDeliveries");
            DropForeignKey("dbo.SaleDeliveries", "TransporterId", "dbo.Customers");
            DropForeignKey("dbo.SaleDeliveries", "SellOrderId", "dbo.SellOrders");
            DropForeignKey("dbo.SellOrders", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.SellOrders", "PartyId", "dbo.Customers");
            DropForeignKey("dbo.SellOrders", "ItemId", "dbo.Items");
            DropForeignKey("dbo.SaleDeliveries", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseDeliveries", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "PartyId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ProductWarranties", "WarrantyModeId", "dbo.WarrantyModes");
            DropForeignKey("dbo.ProductWarranties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInStores", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductInStores", "PersonId", "dbo.NashUsers");
            DropForeignKey("dbo.ProductInStores", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ProductImages", "ImageId", "dbo.ImageUploads");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Payslips", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Payslips", "ApprovalId", "dbo.Approvals");
            DropForeignKey("dbo.PaymentDetails", "PayToTypeId", "dbo.PayToTypes");
            DropForeignKey("dbo.PaymentDetails", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.PaymentDetails", "PaymentStatusId", "dbo.Approvals");
            DropForeignKey("dbo.PaymentDetails", "ImageProofId", "dbo.ImageUploads");
            DropForeignKey("dbo.PaymentDetails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PaymentDetails", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.PageContents", "StaticPageId", "dbo.StaticPages");
            DropForeignKey("dbo.OtherPayments", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.OtherPayments", "ImageProofId", "dbo.ImageUploads");
            DropForeignKey("dbo.OtherPayments", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.OtherPayments", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.OtherPayments", "StatusId", "dbo.Approvals");
            DropForeignKey("dbo.OrderProductWarranties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProductWarranties", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "NashUserId", "dbo.NashUsers");
            DropForeignKey("dbo.Orders", "InvoiceId", "dbo.InvoiceMasters");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.Approvals");
            DropForeignKey("dbo.NewsLetterSubscribers", "NashUserId", "dbo.NashUsers");
            DropForeignKey("dbo.NashUserSessions", "NashUserId", "dbo.NashUsers");
            DropForeignKey("dbo.NashUserRoles", "NashUserId", "dbo.NashUsers");
            DropForeignKey("dbo.NashUsers", "NashUserTypeId", "dbo.NashUserTypes");
            DropForeignKey("dbo.NashUsers", "GenderId", "dbo.GenderTypes");
            DropForeignKey("dbo.NashUsers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.NashUsers", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.NashUserRoles", "NashRoleId", "dbo.NashRoles");
            DropForeignKey("dbo.NashAcls", "RoleId", "dbo.NashRoles");
            DropForeignKey("dbo.NashAcls", "PageId", "dbo.NashPages");
            DropForeignKey("dbo.NashPages", "ParentPageId", "dbo.NashPages");
            DropForeignKey("dbo.MissingItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.MissingItems", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceMasterId", "dbo.InvoiceMasters");
            DropForeignKey("dbo.InvoiceMasters", "ImageUploadId", "dbo.ImageUploads");
            DropForeignKey("dbo.InvoiceMasters", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.InvoiceMasters", "BillToTypeId", "dbo.BillToTypes");
            DropForeignKey("dbo.InventoryStocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryRequests", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryRequests", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.ImportPayments", "PayToTypeId", "dbo.PayToTypes");
            DropForeignKey("dbo.ImportPayments", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.ImportPayments", "MoneyChangerId", "dbo.MoneyChangers");
            DropForeignKey("dbo.MoneyChangers", "MCAccountId", "dbo.Accounts");
            DropForeignKey("dbo.ImportPayments", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.ImportPayments", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.ImportPayments", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.HomePageSlides", "SlideImageId", "dbo.ImageUploads");
            DropForeignKey("dbo.FreightForwarders", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.EmployeeLoans", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeLoans", "ApprovalId", "dbo.Approvals");
            DropForeignKey("dbo.EmployeeBonus", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmailSMSTemplates", "EmailTemplateTypeId", "dbo.EmailTemplateTypes");
            DropForeignKey("dbo.DcSummaries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DcSummaries", "GroupId", "dbo.DcGroups");
            DropForeignKey("dbo.DcSummaries", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.WarrantyOrRepairRequests", "WarrantyStatusId", "dbo.WarrantyRequestStatus");
            DropForeignKey("dbo.WarrantyOrRepairRequests", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "WarrantyModeId", "dbo.WarrantyModes");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.WarrantyOrRepairRequests", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.ClearingAgents", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.Cities", "GeoLocationId", "dbo.GeoLocations");
            DropForeignKey("dbo.Categories", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Manufacturers", "ImageId", "dbo.ImageUploads");
            DropForeignKey("dbo.Categories", "ImageId", "dbo.ImageUploads");
            DropForeignKey("dbo.B2BTransfer", "ToBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.B2BTransfer", "FromBankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.B2BTransfer", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AppointmentTestResults", "AppointmentTestId", "dbo.AppointmentTests");
            DropForeignKey("dbo.AppointmentTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.AppointmentTests", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.AppointmentTestResults", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.AppointmentOffers", "OfferId", "dbo.Offers");
            DropForeignKey("dbo.AppointmentOffers", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.AdvanceSalaries", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.AdvanceSalaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.AdvanceSalaries", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropForeignKey("dbo.AccountsHeads", "LiabilityId", "dbo.Accounts");
            DropForeignKey("dbo.AccountsHeads", "IncomeOrRevenueId", "dbo.Accounts");
            DropForeignKey("dbo.AccountsHeads", "ExpensesId", "dbo.Accounts");
            DropForeignKey("dbo.AccountsHeads", "EquityOrCapitalId", "dbo.Accounts");
            DropForeignKey("dbo.AccountsHeads", "AssetId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ParentAccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "CompanyId", "dbo.NashCompanies");
            DropForeignKey("dbo.NashCompanies", "ImageId", "dbo.ImageUploads");
            DropIndex("dbo.WPQuantities", new[] { "ProductId" });
            DropIndex("dbo.WPQuantities", new[] { "WarehouseId" });
            DropIndex("dbo.Warranties", new[] { "WarrantyModeId" });
            DropIndex("dbo.Warranties", new[] { "OrderId" });
            DropIndex("dbo.Vendors", new[] { "CompanyId" });
            DropIndex("dbo.VendorPurchaseOrders", new[] { "ImageUploadId" });
            DropIndex("dbo.VendorPurchaseOrders", new[] { "VendorId" });
            DropIndex("dbo.VendorPurchaseOrders", new[] { "CompanyId" });
            DropIndex("dbo.VendorPODetails", new[] { "ProductId" });
            DropIndex("dbo.VendorPODetails", new[] { "VendorPurchaseOrderId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.SmsConfigurations", new[] { "SmsTypeId" });
            DropIndex("dbo.SaleDeliveryItems", new[] { "SaleDeliveryId" });
            DropIndex("dbo.SaleDeliveryItems", new[] { "ItemId" });
            DropIndex("dbo.ReturnProducts", new[] { "CustomerId" });
            DropIndex("dbo.ReturnProducts", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDeliveryItems", new[] { "PurchaseDeliveryId" });
            DropIndex("dbo.PurchaseDeliveryItems", new[] { "ItemId" });
            DropIndex("dbo.SellOrders", new[] { "PurchaseOrderId" });
            DropIndex("dbo.SellOrders", new[] { "PartyId" });
            DropIndex("dbo.SellOrders", new[] { "ItemId" });
            DropIndex("dbo.SaleDeliveries", new[] { "TransporterId" });
            DropIndex("dbo.SaleDeliveries", new[] { "PurchaseOrderId" });
            DropIndex("dbo.SaleDeliveries", new[] { "SellOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "PartyId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ItemId" });
            DropIndex("dbo.PurchaseDeliveries", new[] { "SaleDeliveryId" });
            DropIndex("dbo.PurchaseDeliveries", new[] { "PurchaseOrderId" });
            DropIndex("dbo.ProductWarranties", new[] { "WarrantyModeId" });
            DropIndex("dbo.ProductWarranties", new[] { "ProductId" });
            DropIndex("dbo.ProductInStores", new[] { "PersonId" });
            DropIndex("dbo.ProductInStores", new[] { "ProductId" });
            DropIndex("dbo.ProductInStores", new[] { "BranchId" });
            DropIndex("dbo.ProductImages", new[] { "ImageId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.Payslips", new[] { "ApprovalId" });
            DropIndex("dbo.Payslips", new[] { "EmployeeId" });
            DropIndex("dbo.PaymentDetails", new[] { "ImageProofId" });
            DropIndex("dbo.PaymentDetails", new[] { "PaymentStatusId" });
            DropIndex("dbo.PaymentDetails", new[] { "PayToTypeId" });
            DropIndex("dbo.PaymentDetails", new[] { "PaymentTypeId" });
            DropIndex("dbo.PaymentDetails", new[] { "BankAccountId" });
            DropIndex("dbo.PaymentDetails", new[] { "CustomerId" });
            DropIndex("dbo.PageContents", new[] { "StaticPageId" });
            DropIndex("dbo.OtherPayments", new[] { "ImageProofId" });
            DropIndex("dbo.OtherPayments", new[] { "StatusId" });
            DropIndex("dbo.OtherPayments", new[] { "PaymentTypeId" });
            DropIndex("dbo.OtherPayments", new[] { "BankAccountId" });
            DropIndex("dbo.OtherPayments", new[] { "BranchId" });
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            DropIndex("dbo.Orders", new[] { "NashUserId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.OrderProductWarranties", new[] { "ProductId" });
            DropIndex("dbo.OrderProductWarranties", new[] { "OrderId" });
            DropIndex("dbo.NewsLetterSubscribers", new[] { "NashUserId" });
            DropIndex("dbo.NashUserSessions", new[] { "NashUserId" });
            DropIndex("dbo.NashUsers", new[] { "NashUserTypeId" });
            DropIndex("dbo.NashUsers", new[] { "GenderId" });
            DropIndex("dbo.NashUsers", new[] { "BranchId" });
            DropIndex("dbo.NashUsers", new[] { "CityId" });
            DropIndex("dbo.NashUserRoles", new[] { "NashUserId" });
            DropIndex("dbo.NashUserRoles", new[] { "NashRoleId" });
            DropIndex("dbo.NashPages", new[] { "ParentPageId" });
            DropIndex("dbo.NashAcls", new[] { "RoleId" });
            DropIndex("dbo.NashAcls", new[] { "PageId" });
            DropIndex("dbo.MissingItems", new[] { "ProductId" });
            DropIndex("dbo.MissingItems", new[] { "BranchId" });
            DropIndex("dbo.InvoiceMasters", new[] { "ImageUploadId" });
            DropIndex("dbo.InvoiceMasters", new[] { "CompanyId" });
            DropIndex("dbo.InvoiceMasters", new[] { "BillToTypeId" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceMasterId" });
            DropIndex("dbo.InventoryStocks", new[] { "ProductId" });
            DropIndex("dbo.InventoryRequests", new[] { "ProductId" });
            DropIndex("dbo.InventoryRequests", new[] { "BranchId" });
            DropIndex("dbo.MoneyChangers", new[] { "MCAccountId" });
            DropIndex("dbo.ImportPayments", new[] { "MoneyChangerId" });
            DropIndex("dbo.ImportPayments", new[] { "PayToTypeId" });
            DropIndex("dbo.ImportPayments", new[] { "PaymentTypeId" });
            DropIndex("dbo.ImportPayments", new[] { "BankAccountId" });
            DropIndex("dbo.ImportPayments", new[] { "CurrencyId" });
            DropIndex("dbo.ImportPayments", new[] { "CompanyId" });
            DropIndex("dbo.HomePageSlides", new[] { "SlideImageId" });
            DropIndex("dbo.FreightForwarders", new[] { "CompanyId" });
            DropIndex("dbo.EmployeeLoans", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeLoans", new[] { "ApprovalId" });
            DropIndex("dbo.EmployeeBonus", new[] { "EmployeeId" });
            DropIndex("dbo.EmailSMSTemplates", new[] { "EmailTemplateTypeId" });
            DropIndex("dbo.DcSummaries", new[] { "GroupId" });
            DropIndex("dbo.DcSummaries", new[] { "ProductId" });
            DropIndex("dbo.DcSummaries", new[] { "BranchId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "WarrantyModeId" });
            DropIndex("dbo.Customers", new[] { "AccountId" });
            DropIndex("dbo.WarrantyOrRepairRequests", new[] { "WarrantyStatusId" });
            DropIndex("dbo.WarrantyOrRepairRequests", new[] { "CustomerId" });
            DropIndex("dbo.WarrantyOrRepairRequests", new[] { "ProductId" });
            DropIndex("dbo.ClearingAgents", new[] { "CompanyId" });
            DropIndex("dbo.Cities", new[] { "GeoLocationId" });
            DropIndex("dbo.Manufacturers", new[] { "ImageId" });
            DropIndex("dbo.Categories", new[] { "ManufacturerId" });
            DropIndex("dbo.Categories", new[] { "ImageId" });
            DropIndex("dbo.B2BTransfer", new[] { "ToBankAccountId" });
            DropIndex("dbo.B2BTransfer", new[] { "FromBankAccountId" });
            DropIndex("dbo.B2BTransfer", new[] { "BranchId" });
            DropIndex("dbo.AppointmentTests", new[] { "TestId" });
            DropIndex("dbo.AppointmentTests", new[] { "AppointmentId" });
            DropIndex("dbo.AppointmentTestResults", new[] { "AppointmentTestId" });
            DropIndex("dbo.AppointmentTestResults", new[] { "AppointmentId" });
            DropIndex("dbo.AppointmentOffers", new[] { "OfferId" });
            DropIndex("dbo.AppointmentOffers", new[] { "AppointmentId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.BankAccounts", new[] { "BankId" });
            DropIndex("dbo.BankAccounts", new[] { "CompanyId" });
            DropIndex("dbo.AdvanceSalaries", new[] { "EmployeeId" });
            DropIndex("dbo.AdvanceSalaries", new[] { "PaymentTypeId" });
            DropIndex("dbo.AdvanceSalaries", new[] { "BankAccountId" });
            DropIndex("dbo.AccountsHeads", new[] { "EquityOrCapitalId" });
            DropIndex("dbo.AccountsHeads", new[] { "ExpensesId" });
            DropIndex("dbo.AccountsHeads", new[] { "IncomeOrRevenueId" });
            DropIndex("dbo.AccountsHeads", new[] { "LiabilityId" });
            DropIndex("dbo.AccountsHeads", new[] { "AssetId" });
            DropIndex("dbo.NashCompanies", new[] { "ImageId" });
            DropIndex("dbo.Branches", new[] { "CompanyId" });
            DropIndex("dbo.Accounts", new[] { "BranchId" });
            DropIndex("dbo.Accounts", new[] { "ParentAccountId" });
            DropTable("dbo.WPQuantities");
            DropTable("dbo.Warranties");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Vendors");
            DropTable("dbo.VendorPurchaseOrders");
            DropTable("dbo.VendorPODetails");
            DropTable("dbo.Transactions");
            DropTable("dbo.SmsTypes");
            DropTable("dbo.SmsConfigurations");
            DropTable("dbo.SiteSettings");
            DropTable("dbo.SaleDeliveryItems");
            DropTable("dbo.ReturnProducts");
            DropTable("dbo.PurchaseDeliveryItems");
            DropTable("dbo.SellOrders");
            DropTable("dbo.SaleDeliveries");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.PurchaseDeliveries");
            DropTable("dbo.ProductWarranties");
            DropTable("dbo.ProductInStores");
            DropTable("dbo.ProductImages");
            DropTable("dbo.PerformaInvoices");
            DropTable("dbo.Payslips");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.Patients");
            DropTable("dbo.StaticPages");
            DropTable("dbo.PageContents");
            DropTable("dbo.OtherPayments");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProductWarranties");
            DropTable("dbo.NewsLists");
            DropTable("dbo.NewsLetterTemplates");
            DropTable("dbo.NewsLetterSubscribers");
            DropTable("dbo.NewsLetters");
            DropTable("dbo.NewsConfigurations");
            DropTable("dbo.NashUserSessions");
            DropTable("dbo.NashUserTypes");
            DropTable("dbo.NashUsers");
            DropTable("dbo.NashUserRoles");
            DropTable("dbo.NashRoles");
            DropTable("dbo.NashPages");
            DropTable("dbo.NashAcls");
            DropTable("dbo.MissingItems");
            DropTable("dbo.Items");
            DropTable("dbo.InvoiceSummaries");
            DropTable("dbo.InvoiceMasters");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.InventoryStocks");
            DropTable("dbo.InventoryRequests");
            DropTable("dbo.PayToTypes");
            DropTable("dbo.MoneyChangers");
            DropTable("dbo.ImportPayments");
            DropTable("dbo.HomePageSlides");
            DropTable("dbo.GenderTypes");
            DropTable("dbo.FreightForwarders");
            DropTable("dbo.EmployeeLoans");
            DropTable("dbo.EmployeeBonus");
            DropTable("dbo.EmailTemplateTypes");
            DropTable("dbo.EmailSMSTemplates");
            DropTable("dbo.EmailAccounts");
            DropTable("dbo.DcSummaries");
            DropTable("dbo.DcGroups");
            DropTable("dbo.Currencies");
            DropTable("dbo.WarrantyRequestStatus");
            DropTable("dbo.WarrantyModes");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.WarrantyOrRepairRequests");
            DropTable("dbo.CourierCompanies");
            DropTable("dbo.CompanySettings");
            DropTable("dbo.ClearingAgents");
            DropTable("dbo.GeoLocations");
            DropTable("dbo.Cities");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.BillToTypes");
            DropTable("dbo.B2BTransfer");
            DropTable("dbo.Approvals");
            DropTable("dbo.Tests");
            DropTable("dbo.AppointmentTests");
            DropTable("dbo.AppointmentTestResults");
            DropTable("dbo.Offers");
            DropTable("dbo.Appointments");
            DropTable("dbo.AppointmentOffers");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Designations");
            DropTable("dbo.Employees");
            DropTable("dbo.Banks");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.AdvanceSalaries");
            DropTable("dbo.AccountsHeads");
            DropTable("dbo.ImageUploads");
            DropTable("dbo.NashCompanies");
            DropTable("dbo.Branches");
            DropTable("dbo.Accounts");
        }
    }
}
