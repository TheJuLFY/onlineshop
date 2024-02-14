namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class ProductRepository : IProductRepository
    {
        private DatabaseContext context;

        public ProductRepository(DatabaseContext context)
        {
            this.context = context;
        }

        async Task<List<Product>> IProductRepository.GetProducts()
        {
            return await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await context.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> InsertProduct(Product product)
        {
            var entity = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return await context.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == product.Id);
        }

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            var entity = await context.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return null;
            }

            entity.Name = product.Name;
            entity.CategoryId = product.CategoryId;
            entity.Description = product.Description;
            entity.ImageUrl = product.ImageUrl;
            entity.Price = product.Price;
            entity.Tonnage = product.Tonnage;
            entity.Region = product.Region;

            await context.SaveChangesAsync();
            return await context.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var entity = await context.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return false;
            }

            context.Products.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
