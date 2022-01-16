namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IB2BTransferService
    {
        B2BTransferViewModel CreateB2BTransfer(B2BTransferBindingModel model, int userId);
        bool DeleteB2BTransfer(int B2BTransferId);
        B2BTransferViewModel GetB2BTransferByB2BTransferId(int B2BTransferId);
        NashPagedList<B2BTransferViewModel> GetB2BTransfer(int rows, int pageNumber);
        B2BTransferViewModel UpdateB2BTransfer(B2BTransferBindingModel model, int userId);
    }
}

