namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext context;

        public CategoryRepository(DatabaseContext context)
        {
            this.context = context;
        }

        async Task<List<Category>> ICategoryRepository.GetCategories()
        {
            return await context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await context.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category> InsertCategory(Category category)
        {
            var entity = await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Category> UpdateCategory(Guid id, Category category)
        {
            var entity = await context.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return null;
            }

            entity.Name = category.Name;
            entity.Description = category.Description;
            entity.ImageUrl = category.ImageUrl;

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var entity = await context.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return false;
            }

            context.Categories.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
