namespace Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();

        Task<Category> GetCategory(Guid id);

        Task<Category> InsertCategory(Category category);

        Task<Category> UpdateCategory(Guid id, Category category);

        Task<bool> DeleteCategory(Guid id);
    }
}
