namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        CategoryViewModel CreateCategory(CategoryBindingModel model, int userId);
        bool DeleteCategory(int CategoryId);
        CategoryViewModel GetCategoryByCategoryId(int CategoryId);
        NashPagedList<CategoryViewModel> GetCategory(int rows, int pageNumber , string SearchString = "");
        CategoryViewModel UpdateCategory(CategoryBindingModel model, int userId);
    }
}

