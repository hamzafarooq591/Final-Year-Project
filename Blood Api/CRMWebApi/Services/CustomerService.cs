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

    public class CustomerService : ICustomerService
    {
        public CustomerViewModel CreateCustomer(CustomerBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            NashWebApi.NashContext accContext = new NashWebApi.NashContext();

            AccountRepository accountRepository = new AccountRepository(accContext);

            AccountBindingModel accountBindingModel = new AccountBindingModel
            {
                AccountName = model.CustomerName,
                BranchId = new BranchRepository(context).GetAll().FirstOrDefault<Branch>().Id
             
            };

            var customerNewAccount = accountBindingModel.ToEntity(userId, null);

            using (UnitOfWork work = new UnitOfWork(accContext))
            {
                customerNewAccount = accountRepository.Add(customerNewAccount);
                work.Complete();
            }
            

            Customer entity = model.ToEntity(userId, null);

            entity.AccountId = customerNewAccount.Id;
            
            CustomerViewModel model2 = new CustomerViewModel();
            CustomerRepository repository = new CustomerRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteCustomer(int CustomerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CustomerRepository repository = new CustomerRepository(context);
            Customer entity = repository.FindOne(CustomerId).FirstOrDefault<Customer>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CustomerId. Customer Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public CustomerViewModel GetCustomerByCustomerId(int CustomerId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CustomerRepository repository = new CustomerRepository(context);
            if (repository.FindOne(CustomerId).FirstOrDefault<Customer>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CustomerId. Customer Not Found.");
            }
            return repository.FindOneMapped(CustomerId);
        }

        public NashPagedList<CustomerViewModel> GetCustomer(int rows, int pageNumber, bool? isTransporter = null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CustomerRepository repository = new CustomerRepository(context);
            return repository.Filter(rows, pageNumber,isTransporter).ToViewModel();
        }
        
        public CustomerViewModel UpdateCustomer(CustomerBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            CustomerRepository repository = new CustomerRepository(context);
            int? CustomerId = model.CustomerId;
            Customer original = repository.FindOne(CustomerId.HasValue ? CustomerId.GetValueOrDefault() : 0).FirstOrDefault<Customer>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid CustomerId. Customer Not Found.");
            }
            Customer entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetCustomerByCustomerId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

