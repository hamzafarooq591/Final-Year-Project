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

    public class PayslipService : IPayslipService
    {
        public PayslipViewModel CreatePayslip(PayslipBindingModel model, int userId)
        {
            Payslip entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            PayslipViewModel model2 = new PayslipViewModel();
            PayslipRepository repository = new PayslipRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeletePayslip(int PayslipId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayslipRepository repository = new PayslipRepository(context);
            Payslip entity = repository.FindOne(PayslipId).FirstOrDefault<Payslip>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayslipId. Payslip Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public PayslipViewModel GetPayslipByPayslipId(int PayslipId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayslipRepository repository = new PayslipRepository(context);
            if (repository.FindOne(PayslipId).FirstOrDefault<Payslip>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayslipId. Payslip Not Found.");
            }
            return repository.FindOneMapped(PayslipId);
        }

        public NashPagedList<PayslipViewModel> GetPayslip(int rows, int pageNumber)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayslipRepository repository = new PayslipRepository(context);
            return repository.Filter(rows, pageNumber).ToViewModel();
        }
        
        public PayslipViewModel UpdatePayslip(PayslipBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            PayslipRepository repository = new PayslipRepository(context);
            int? PayslipId = model.PayslipId;
            Payslip original = repository.FindOne(PayslipId.HasValue ? PayslipId.GetValueOrDefault() : 0).FirstOrDefault<Payslip>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid PayslipId. Payslip Not Found.");
            }
            Payslip entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetPayslipByPayslipId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

