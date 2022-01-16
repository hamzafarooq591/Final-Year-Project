namespace NashWebApi.Services
{
    using NashWebApi;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers;
    using NashWebApi.Repositories;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;

    public class SaleDeliveryService : ISaleDeliveryService
    {
        public SaleDeliveryViewModel CreateSaleDelivery(SaleDeliveryBindingModel model, int userId)
        {

            // ------- update purchase order remaining quantity --------------

            NashWebApi.NashContext selectedPurchaseContext = new NashWebApi.NashContext();
            PurchaseOrderRepository selectedPurchaseOrderRepository = new PurchaseOrderRepository(selectedPurchaseContext);
            PurchaseOrder purchaseOrder = selectedPurchaseOrderRepository.Get(model.PurchaseOrderId);

            using (UnitOfWork work = new UnitOfWork(selectedPurchaseContext))
            {

                purchaseOrder.ReminingWeight = model.PurchaseOrderRemainingQuantity;

                selectedPurchaseOrderRepository.Edit(purchaseOrder);
                work.Complete();
            }

            // ------- update sale order remaining quantity --------------

            NashWebApi.NashContext saleContext = new NashWebApi.NashContext();
            SellOrderRepository saleOrderRepository = new SellOrderRepository(saleContext);
            SellOrder saleOrder = saleOrderRepository.Get(model.SellOrderId);

            using (UnitOfWork work = new UnitOfWork(saleContext))
            {

                saleOrder.ReminingWeight = model.SaleOrderRemainingQuantity;

                saleOrderRepository.Edit(saleOrder);
                work.Complete();
            }

            NashWebApi.NashContext context = new NashWebApi.NashContext();
            
            int saleDeliveryId = 0;

            SaleDelivery entity = model.ToEntity(userId, null);
            
            SaleDeliveryViewModel model2 = new SaleDeliveryViewModel();
            SaleDeliveryRepository repository = new SaleDeliveryRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();

                saleDeliveryId = entity.Id;

                model2 = repository.FindOneMapped(entity.Id);
            }

            foreach(var Item in model.saleDeliveryItems)
            {
                Item.SaleDeliveryId = saleDeliveryId;

                NashWebApi.NashContext ItemContext = new NashWebApi.NashContext();
                SaleDeliveryItemRepository saleDeliveryItemRepository = new SaleDeliveryItemRepository(ItemContext);
                SaleDeliveryItem saleDeliveryItem = Item.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(ItemContext))
                {
                    saleDeliveryItemRepository.Add(saleDeliveryItem);
                    work.Complete();
                }

            }


            // ------- create purchase delivery -----------------

            NashWebApi.NashContext purchaseContext = new NashWebApi.NashContext();
            PurchaseDeliveryRepository purchaseDeliveryRepository = new PurchaseDeliveryRepository(purchaseContext);
            PurchaseDeliveryBindingModel purchaseDeliveryBindingModel = new PurchaseDeliveryBindingModel();

            purchaseDeliveryBindingModel.PurchaseOrderId = model.PurchaseOrderId;
            purchaseDeliveryBindingModel.SaleDeliveryId = saleDeliveryId;

            PurchaseDelivery purchaseDelivery = purchaseDeliveryBindingModel.ToEntity(userId, null);

            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository(purchaseContext);

            purchaseDelivery.PurchaseOrder = purchaseOrderRepository.Get(model.PurchaseOrderId);

            purchaseDelivery.PurchaseBookingRateMund = purchaseDelivery.PurchaseOrder.Rate;

            purchaseDelivery.PurchaseDeliveryDate = DateTime.Now;


            int purchaseDeliveryId = 0;

            
            decimal purchaseBookingRateMund = 0;
            decimal mundRateIntoKG = 0;

            CompanySettingRepository companySettingRepository = new CompanySettingRepository(purchaseContext);
            mundRateIntoKG = companySettingRepository.GetAll().FirstOrDefault<CompanySetting>().MundRateInKG;
            
            using (UnitOfWork work = new UnitOfWork(purchaseContext))
            {
                purchaseDelivery = purchaseDeliveryRepository.Add(purchaseDelivery);
                work.Complete();

                purchaseDeliveryId = purchaseDelivery.Id;
                purchaseBookingRateMund = purchaseDelivery.PurchaseBookingRateMund;

            }

            // --------- adding purchase booking items ------------

            decimal purchaseDeliveryTotalAmount = 0;

            foreach (var Item in model.saleDeliveryItems)
            {
                NashWebApi.NashContext ItemContext = new NashWebApi.NashContext();
                PurchaseDeliveryItemRepository purchaseDeliveryItemRepository = new PurchaseDeliveryItemRepository(ItemContext);
                SaleDeliveryItem saleDeliveryItem = Item.ToEntity(userId, null);

                PurchaseDeliveryItemBindingModel purchaseDeliveryItemBindingModel = new PurchaseDeliveryItemBindingModel();

                purchaseDeliveryItemBindingModel.ItemName = Item.ItemName;
                purchaseDeliveryItemBindingModel.PurchaseDeliveryId = purchaseDeliveryId;
                purchaseDeliveryItemBindingModel.Quantity = Item.Quantity;

                // ----- calculate Sale Delivery Rate of Item ------
                // Sale Delivery Rate = (((Purchase Booking Rate(Mund) +Item Milling Rate ) / MuND Rate into KG ) *Item Quantity(KG)) +Item Packaging Rate

                decimal saleDeliveryRate = 0;

                ItemRepository itemRepository = new ItemRepository(ItemContext);

                saleDeliveryItem.Item = itemRepository.Get(saleDeliveryItem.ItemId.Value);

                decimal itemMillingRate = saleDeliveryItem.Item.MilingRate;
                decimal itemQuantityKG = saleDeliveryItem.Item.QuantityWeightKG;
                decimal itemPackagingRate = saleDeliveryItem.Item.PackagingRate;


                saleDeliveryRate = (((purchaseBookingRateMund + itemMillingRate) / mundRateIntoKG)
                    * itemQuantityKG) + itemPackagingRate;

                purchaseDeliveryItemBindingModel.ItemRate = saleDeliveryRate;
                purchaseDeliveryItemBindingModel.Total = saleDeliveryRate * Item.Quantity;

                PurchaseDeliveryItem purchaseDeliveryItem = purchaseDeliveryItemBindingModel.ToEntity(userId, null);
                
                using (UnitOfWork work = new UnitOfWork(ItemContext))
                {
                    purchaseDeliveryItemRepository.Add(purchaseDeliveryItem);
                    work.Complete();
                }

                purchaseDeliveryTotalAmount += purchaseDeliveryItemBindingModel.Total;

            }

            // ------ updating purchase delivery Total ------------

            NashWebApi.NashContext purchaseUpdateContext = new NashWebApi.NashContext();
            PurchaseDeliveryRepository purchaseUpdateDeliveryRepository = new PurchaseDeliveryRepository(purchaseUpdateContext);
            var purchaseUpdateDelivery = purchaseUpdateDeliveryRepository.Get(purchaseDeliveryId);

            purchaseUpdateDelivery.TotalAmount = purchaseDeliveryTotalAmount;

            using (UnitOfWork work = new UnitOfWork(purchaseUpdateContext))
            {
                purchaseUpdateDeliveryRepository.Edit(purchaseUpdateDelivery);
                work.Complete();

            }
            

            // Debit in Customer Account

            var sellOrderId = model2.SellOrderId;
            var purchaseOrderId = model2.PurchaseOrderId;

            NashWebApi.NashContext customerTransactionContext = new NashWebApi.NashContext();
            NashWebApi.NashContext partyTransactionContext = new NashWebApi.NashContext();


            SellOrderRepository sellOrderRepository = new SellOrderRepository(customerTransactionContext);
            var sellorder = sellOrderRepository.FindOne(sellOrderId).FirstOrDefault<SellOrder>();
            var customerAccountId = sellorder.Party.Account.Id;

            TransactionRepository transactionRepository = new TransactionRepository(customerTransactionContext);

            TransactionBindingModel transactionBindingModel = new TransactionBindingModel();
            transactionBindingModel.AccountId = customerAccountId;
            transactionBindingModel.Amount = float.Parse(model2.TotalAmount.ToString());
            // TransactionType == true is Credit and TransactionType == false is Debit
            transactionBindingModel.TransactionType = false;
            transactionBindingModel.TransactionDescription = "sale delivery no : " + model2.SaleDeliveryId;
            transactionBindingModel.RelatedEntityId = model2.SaleDeliveryId;
           

            Transaction transaction = transactionBindingModel.ToEntity(userId, null);


            using (UnitOfWork work = new UnitOfWork(customerTransactionContext))
            {
                transactionRepository.Add(transaction);
                work.Complete();
            }

            // Credit in Party Account

            PurchaseOrderRepository saledeliveryPurchaseOrderRepo = new PurchaseOrderRepository(partyTransactionContext);
            var partyAccountId = saledeliveryPurchaseOrderRepo.FindOne(purchaseOrderId).FirstOrDefault<PurchaseOrder>()
                .Party.Account.Id;

            transactionRepository = new TransactionRepository(partyTransactionContext);

            transactionBindingModel = new TransactionBindingModel();
            transactionBindingModel.AccountId = partyAccountId;
            transactionBindingModel.Amount = float.Parse(purchaseDeliveryTotalAmount.ToString());
            // TransactionType == true is Credit and TransactionType == false is Debit
            transactionBindingModel.TransactionType = true;
            transactionBindingModel.TransactionDescription = "purchase delivery no : " + purchaseDelivery.Id;
            transactionBindingModel.RelatedEntityId = model2.SaleDeliveryId;

            transaction = transactionBindingModel.ToEntity(userId, null);

            using (UnitOfWork work = new UnitOfWork(partyTransactionContext))
            {
                transactionRepository.Add(transaction);
                work.Complete();
            }


            // X-MILL check == true ? X-MILL : FOB  
            // if X-MILL check == false then Credit in transport account

            if (model.isXMILL == false)
            {
                NashWebApi.NashContext transporterContext = new NashWebApi.NashContext();
                CustomerRepository customerRepository = new CustomerRepository(transporterContext);

               var transporterAccountId = customerRepository.FindOne(model.TransporterId.Value)
                    .FirstOrDefault<Customer>().Account.Id;

                transactionRepository = new TransactionRepository(transporterContext);

                transactionBindingModel = new TransactionBindingModel();
                transactionBindingModel.AccountId = transporterAccountId;
                transactionBindingModel.Amount = float.Parse(model.TransportCharges.ToString());
                // TransactionType == true is Credit and TransactionType == false is Debit
                transactionBindingModel.TransactionType = true;
                transactionBindingModel.TransactionDescription = "transport charges of sale delivery no : " + model2.SaleDeliveryId;
                transactionBindingModel.RelatedEntityId = model2.SaleDeliveryId;

                transaction = transactionBindingModel.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(transporterContext))
                {
                    transactionRepository.Add(transaction);
                    work.Complete();
                }

            }

            if (model.InsuranceCharges > 0)
            {
                NashWebApi.NashContext insurranceContext = new NashWebApi.NashContext();
                CustomerRepository customerRepository = new CustomerRepository(insurranceContext);

                var insurranceAccountId = 24; // insurranceAccount

                transactionRepository = new TransactionRepository(insurranceContext);

                transactionBindingModel = new TransactionBindingModel();
                transactionBindingModel.AccountId = insurranceAccountId;
                transactionBindingModel.Amount = float.Parse(model.InsuranceCharges.ToString());
                // TransactionType == true is Credit and TransactionType == false is Debit
                transactionBindingModel.TransactionType = true;
                transactionBindingModel.TransactionDescription = "insurrance charges of sale delivery no : " + model2.SaleDeliveryId;

                transaction = transactionBindingModel.ToEntity(userId, null);

                using (UnitOfWork work = new UnitOfWork(insurranceContext))
                {
                    transactionRepository.Add(transaction);
                    work.Complete();
                }
            }

            


            return model2;
        }

        public bool DeleteSaleDelivery(int SaleDeliveryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext purchaseContext = new NashWebApi.NashContext();
            NashWebApi.NashContext saleDeliveryTransactionContext = new NashWebApi.NashContext();
            NashWebApi.NashContext saleOrderContext = new NashWebApi.NashContext();
            NashWebApi.NashContext purchaseOrderContext = new NashWebApi.NashContext();

            SaleDeliveryRepository repository = new SaleDeliveryRepository(context);
            PurchaseDeliveryRepository purchaseDeliveryRepository = new PurchaseDeliveryRepository(purchaseContext);
            TransactionRepository saleDeliveryTransactionRepository = new TransactionRepository(saleDeliveryTransactionContext);
            SellOrderRepository SaleOrderRepository = new SellOrderRepository(saleOrderContext);
            PurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository(purchaseOrderContext);


            // ---------------- Delete Sale Delivery ----------------------------------

            SaleDelivery entity = repository.FindOne(SaleDeliveryId).FirstOrDefault<SaleDelivery>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryId. SaleDelivery Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }

            // ---------------- Delete Purchase Delivery ----------------------------------

            PurchaseDelivery purchaseDelivery = purchaseDeliveryRepository.GetAll()
                .Where<PurchaseDelivery>(x => x.SaleDeliveryId == SaleDeliveryId).FirstOrDefault<PurchaseDelivery>();

            purchaseDelivery.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(purchaseContext))
            {
                purchaseDeliveryRepository.Edit(purchaseDelivery);
                work.Complete();
            }

            // ---------------- Delete Sale Delivery Transactions ----------------------------------

            var transactions = saleDeliveryTransactionRepository.GetAll().ToList<Transaction>();

            foreach(var transaction in transactions)
            {
                NashContext transactionContext = new NashContext();
                TransactionRepository transactionRepository = new TransactionRepository(transactionContext);

                transaction.IsDeleted = true;
                using (UnitOfWork work = new UnitOfWork(transactionContext))
                {
                    transactionRepository.Edit(transaction);
                    work.Complete();
                }
                
            }

            // ---------------- Send Quantity Back to Sale and Purchase Order ----------------------------------


            NashContext saleDeliveryItemContext = new NashContext();
            SaleDeliveryItemRepository saleDeliveryItemRepository = new SaleDeliveryItemRepository(saleDeliveryItemContext);

            decimal totalQuantity = 0;

            var saleDeliveryItemList = saleDeliveryItemRepository.GetAll()
                .Where<SaleDeliveryItem>(x => x.SaleDeliveryId == SaleDeliveryId).ToList<SaleDeliveryItem>();

            foreach(SaleDeliveryItem saleDeliveryItem in saleDeliveryItemList)
            {
                totalQuantity += (saleDeliveryItem.ItemWeightKG * saleDeliveryItem.Quantity);
            }

            PurchaseOrder purchaseOrder = purchaseOrderRepository.Get(entity.PurchaseOrderId);
            purchaseOrder.ReminingWeight += totalQuantity;

            SellOrder sellOrder = SaleOrderRepository.Get(entity.SellOrderId);
            sellOrder.ReminingWeight += totalQuantity;


            using (UnitOfWork work = new UnitOfWork(purchaseOrderContext))
            {
                purchaseOrderRepository.Edit(purchaseOrder);
                work.Complete();
            }

            using (UnitOfWork work = new UnitOfWork(saleOrderContext))
            {
                SaleOrderRepository.Edit(sellOrder);
                work.Complete();
            }
            

            return true;
        }
        
        public SaleDeliveryViewModel GetSaleDeliveryBySaleDeliveryId(int SaleDeliveryId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryRepository repository = new SaleDeliveryRepository(context);
            if (repository.FindOne(SaleDeliveryId).FirstOrDefault<SaleDelivery>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryId. SaleDelivery Not Found.");
            }

            var saleDeliveryViewModel = repository.FindOneMapped(SaleDeliveryId);

            SaleDeliveryItemRepository saleDeliveryItemRepository = new SaleDeliveryItemRepository(context);

            saleDeliveryViewModel.saleDeliveryItems = saleDeliveryItemRepository.ListBySaleDeliveryId(SaleDeliveryId).ToViewModel();

            return saleDeliveryViewModel;
        }

        public NashPagedList<SaleDeliveryViewModel> GetSaleDelivery(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryRepository repository = new SaleDeliveryRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public SaleDeliveryViewModel UpdateSaleDelivery(SaleDeliveryBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            SaleDeliveryRepository repository = new SaleDeliveryRepository(context);
            SaleDeliveryViewModel model2 = new SaleDeliveryViewModel();
            int? SaleDeliveryId = model.SaleDeliveryId;
            SaleDelivery original = repository.FindOne(SaleDeliveryId.HasValue ? SaleDeliveryId.GetValueOrDefault() : 0).FirstOrDefault<SaleDelivery>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid SaleDeliveryId. SaleDelivery Not Found.");
            }
            SaleDelivery entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetSaleDeliveryBySaleDeliveryId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

