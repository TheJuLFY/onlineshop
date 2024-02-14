namespace Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(Guid id);

        Task<Product> InsertProduct(Product product);

        Task<Product> UpdateProduct(Guid id, Product product);

        Task<bool> DeleteProduct(Guid id);
    }
}
