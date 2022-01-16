namespace NashWebApi
{
    using NashWebApi.Entities;
    using NashWebApi.Entities.BloodLab;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Runtime.CompilerServices;

    public class NashContext : DbContext
    {
        public NashContext() : base("NashContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }


        public DbSet<AccountsHead> AccountsHeads { get; set; }

        public DbSet<B2BTransfer> B2BTransfers { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BillToType> BillToTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentTest> AppointmentTests { get; set; }

        public DbSet<AppointmentTestResult> AppointmentTestResults { get; set; }

        public DbSet<AppointmentOffer> AppointmentOffers { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<AppointmentSlot> AppointmentSlots { get; set; }





        public DbSet<ClearingAgent> ClearingAgents { get; set; }

        public DbSet<CourierCompany> CourierCompanies { get; set; }
        
        public DbSet<Currency> Currencys { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<WarrantyOrRepairRequest> CreateWarrantys { get; set; }
        
        public DbSet<DcGroup> DcGroups { get; set; }
        
        public DbSet<DcSummary> DcSummaries { get; set; }

        public DbSet<EmailAccount> EmailAccounts { get; set; }

        public DbSet<EmailSMSTemplate> EmailSMSTemplates { get; set; }

        public DbSet<EmailTemplateType> EmailTemplateTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeBonus> EmployeeBonuses { get; set; }

        public DbSet<EmployeeLoan> EmployeeLoanes { get; set; }
        
        public DbSet<FreightForwarder> FreightForwarders { get; set; }

        public DbSet<HomePageSlide> HomePageSlides { get; set; }
        
        public DbSet<InventoryStock> InventoryStocks { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<InvoiceSummary> InvoiceSummaries { get; set; }
        
        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }

        public DbSet<Approval> Approvals { get; set; }

        public DbSet<AdvanceSalary> AdvanceSalaries { get; set; }
        
        public DbSet<NewsList> NewsLists { get; set; }

        public DbSet<OrderProductWarranty> OrderProductWarranties { get; set; }
        
        public DbSet<Payslip> Payslips { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }
        
        public DbSet<PayToType> PayToTypes { get; set; }

        public DbSet<PerformaInvoice> PerformaInvoices { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<GenderType> GenderTypes { get; set; }

        public DbSet<GeoLocation> GeoLocations { get; set; }

        public DbSet<ImageUpload> ImageUploads { get; set; }
        
        public DbSet<ImportPayment> ImportPayments { get; set; }

        public DbSet<InventoryRequest> InventoryRequests { get; set; }
        
        public DbSet<MoneyChanger> MoneyChangers { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }

        public DbSet<NashAcl> NashAcls { get; set; }

        public DbSet<NashPage> NashPages { get; set; }

        public DbSet<NashRole> NashRoles { get; set; }

        public DbSet<NashUserRole> NashUserRoles { get; set; }

        public DbSet<NashUser> NashUsers { get; set; }

        public DbSet<NashUserType> NashUserTypes { get; set; }

        public DbSet<NashUserSession> NashUserSessions { get; set; }

        public DbSet<NashCompany> NashCompanies { get; set; }

        public DbSet<NewsConfiguration> NewsConfigurations { get; set; }
        
        public DbSet<ProductInStore> ProductInStores { get; set; }

        public DbSet<MissingItem> MissingItems { get; set; }

        public DbSet<NewsLetterSubscriber> NewsLetterSubscribers { get; set; }

        public DbSet<NewsLetterTemplate> NewsLetterTemplates { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OtherPayment> OtherPayments { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<PageContent> PageContents { get; set; }
        
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        
        public DbSet<ProductWarranty> ProductWarranties { get; set; }

        public DbSet<ReturnProduct> ReturnProducts { get; set; }
        
        public DbSet<SiteSetting> SiteSettings { get; set; }
        
        public DbSet<SmsConfiguration> SmsConfigurations { get; set; }

        public DbSet<SmsType> SmsTypes { get; set; }

        public DbSet<StaticPage> StaticPages { get; set; }
        
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        
        public DbSet<Vendor> Vendors { get; set; }
        
        public DbSet<VendorPurchaseOrder> VendorPurchaseOrders { get; set; }
        
        public DbSet<VendorPODetail> VendorPODetails { get; set; }
        
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Warranty> Warranties { get; set; }

        public DbSet<WarrantyMode> WarrantyModes { get; set; }

        public DbSet<WarrantyRequestStatus> WarrantyRequestStatuses { get; set; }
        
        public DbSet<WPQuantity> WPQuantities { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }

        public DbSet<CompanySetting> companySettings { get; set; }

        public DbSet<SaleDelivery> SaleDeliveries { get; set; }
        public DbSet<SaleDeliveryItem> SaleDeliveryItems { get; set; }

        public DbSet<PurchaseDelivery> PurchaseDeliveries { get; set; }
        public DbSet<PurchaseDeliveryItem> PurchaseDeliveryItems { get; set; }
    }
}

