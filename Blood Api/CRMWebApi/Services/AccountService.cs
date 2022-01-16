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

    public class AccountService : IAccountService
    {
        public AccountViewModel CreateAccount(AccountBindingModel model, int userId)
        {
            Account entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            AccountViewModel model2 = new AccountViewModel();
            AccountRepository repository = new AccountRepository(context);
            Account account = repository.GetAll().
                FirstOrDefault(x => x.AccountName.Contains(entity.AccountName));
            if (entity.ParentAccountId == null)
            {
                entity.AccountHeadId = null;
            }
            else if (entity.ParentAccountId != null)
            {
                entity.ParentAccount = repository.Get(entity.ParentAccountId.Value);

                if (entity.ParentAccount.AccountHeadId == null)
                {
                    entity.AccountHeadId = entity.ParentAccountId;
                }
                else if (entity.ParentAccount.AccountHeadId != null)

                    entity.AccountHeadId = entity.ParentAccount.AccountHeadId;
            }
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (account != null)
                {
                    throw new NashHandledExceptionNotFound("Account Name already Exist, Try another Name");
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteAccount(int AccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);
            TransactionRepository transactionRepository = new TransactionRepository(context);
            Account entity = repository.FindOne(AccountId).FirstOrDefault<Account>();
            Transaction transaction = transactionRepository.GetAll()
                .FirstOrDefault(x => x.AccountId == entity.Id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountId. Account Not Found.");
            }
            if (transaction != null)
            {
                return false;
            }
           // if (entity.AccountHeadId != null)
           // {
                entity.IsDeleted = true;
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    repository.Edit(entity);
                    work.Complete();
                }
                return true;
            //}
            //else
              //  throw new NashException("Head Account can't be deleted.");
        }

        public AccountViewModel GetAccountByAccountId(int AccountId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);
            if (repository.FindOne(AccountId).FirstOrDefault<Account>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountId. Account Not Found.");
            }
            var result = repository.FindOneMapped(AccountId);

            return result;
        }

        public NashPagedList<AccountViewModel> GetAccount(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber, BranchId).ToViewModel();

            return result;
        }

        public AccountViewModel UpdateAccount(AccountBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);
            int? AccountId = model.AccountId;
            Account original = repository.FindOne(AccountId.HasValue ? AccountId.GetValueOrDefault() : 0).FirstOrDefault<Account>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid AccountId. Account Not Found.");
            }
            Account entity = model.ToEntity(userId, original);
            if (entity.ParentAccountId == null)
            {
                entity.AccountHeadId = null;
            }
            else if (entity.ParentAccountId != null)
            {
                if (entity.ParentAccount.AccountHeadId == null)
                {
                    entity.AccountHeadId = entity.ParentAccountId;
                }
                else if (entity.ParentAccount.AccountHeadId != null)
                {
                    entity.AccountHeadId = entity.ParentAccount.AccountHeadId;
                }
            }
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetAccountByAccountId(entity.Id);
        }

        public NashPagedList<TrailBalanceViewModel> GetTrailBalance(int rows, int pageNumber, string SearchString = "")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);

            TransactionRepository transactionRepository = new TransactionRepository(context);

            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.GetTrailBalance(rows, pageNumber, SearchString).ToTrailBalanceViewModel();

            foreach (var acc in result.Data)
            {
                acc.TotalCredit = transactionRepository
                    .TotalTransactionAmountByAccountIdAndTransactionType(acc.AccountId, true);
                acc.TotalDebit = transactionRepository
                    .TotalTransactionAmountByAccountIdAndTransactionType(acc.AccountId, false);
            }

            return result;
        }
        public NashPagedList<AccountViewModel> GetParentAccount(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository repository = new AccountRepository(context);

            var result = repository.FilterforParentAccount(rows, pageNumber).ToViewModel();

            return result;
        }

        public class AccountChild
        {
            public int accountId {get;set;}
            public float totaldebit { get; set; }
            public float totalcredit { get; set; }
        }

        //get Profit & Loss()
        public ProfitLossReportViewModel GetProfitAndLoss()
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            AccountRepository accountrepository = new AccountRepository(context);
            TransactionRepository transactionRepository = new TransactionRepository(context);
            AccountsHeadRepository accountsHeadRepository = new AccountsHeadRepository(context);
            int IncomeAccountId, ExpenseAccountId;

            var IncomeAccountList = new List<AccountChild>();
            var ExpenseAccountList = new List<AccountChild>();

            var accountHead = accountsHeadRepository.GetAll().FirstOrDefault();

            IncomeAccountId = accountHead.IncomeOrRevenueId;
            ExpenseAccountId = accountHead.ExpensesId;
            List<Account> IncomeAccounts = null;

            IncomeAccounts = accountrepository.GetChildAccountsByAccountHeadId(IncomeAccountId).ToList();

            foreach (var account in IncomeAccounts)
            {
                AccountChild accountChild = new AccountChild();
            accountChild.accountId = account.Id;
            accountChild.totalcredit = transactionRepository.TotalTransactionAmountByAccountIdAndTransactionType(account.Id, transactionType: true);
            accountChild.totaldebit = transactionRepository.TotalTransactionAmountByAccountIdAndTransactionType(account.Id, transactionType: false);

                IncomeAccountList.Add(accountChild);
            }

            var ExpenseAccounts = accountrepository.GetChildAccountsByAccountHeadId(ExpenseAccountId).ToList();
            foreach (var account in ExpenseAccounts)
            {
                AccountChild accountChild = new AccountChild();
                accountChild.accountId = account.Id;
                accountChild.totalcredit = transactionRepository.TotalTransactionAmountByAccountIdAndTransactionType(account.Id, transactionType: true);
                accountChild.totaldebit = transactionRepository.TotalTransactionAmountByAccountIdAndTransactionType(account.Id, transactionType: false);

                ExpenseAccountList.Add(accountChild);

            }

            float TotalIncomeAccountBalance = 0;
            float TotalExpenseAccountBalance = 0;
            float TotalIncomeAccountCredit = 0;
            float TotalIncomeAccountDebit = 0;
            float TotalExpenseAccountCredit = 0;
            float TotalExpenseAccountDebit = 0;

            foreach (var incomeAccount in IncomeAccountList)
            {
                TotalIncomeAccountCredit += incomeAccount.totalcredit;
                TotalIncomeAccountDebit += incomeAccount.totaldebit; 
            }

            TotalIncomeAccountBalance = TotalIncomeAccountDebit - TotalIncomeAccountCredit;

            foreach (var expenseAccount in ExpenseAccountList)
            {
                TotalExpenseAccountCredit += expenseAccount.totalcredit;
                TotalExpenseAccountDebit += expenseAccount.totaldebit;
            }
            
            TotalExpenseAccountBalance = TotalExpenseAccountDebit - TotalExpenseAccountCredit;
            
            ProfitLossReportViewModel profitLossReportViewModel = new ProfitLossReportViewModel();

            profitLossReportViewModel.TotalExpense = TotalExpenseAccountBalance;
            profitLossReportViewModel.TotalIncome = TotalIncomeAccountBalance;

            return profitLossReportViewModel;
        }
        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

