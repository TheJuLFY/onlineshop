namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Domain.Models;
    using Domain.Repository;

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var categoriesModel = await _categoryRepository.GetCategories();

            foreach (Category category in categoriesModel)
            {
                category.Products = null;
            }

            var entity = categoriesModel.Select(x => new CategoryDto(x)).ToList();

            return entity;
        }

        public async Task<CategoryDto> GetCategory(Guid id)
        {
            var categoryModel = await _categoryRepository.GetCategory(id);

            if (categoryModel is null)
            {
                return null;
            }

            return new CategoryDto(categoryModel);
        }

        public async Task<CategoryDto> InsertCategory(CategoryCreateRequestDto category)
        {
            var categoryModel = await _categoryRepository.InsertCategory(category.ToModel());

            return new CategoryDto(categoryModel);
        }

        public async Task<CategoryDto> UpdateCategory(Guid id, CategoryCreateRequestDto category)
        {
            var categoryModel = await _categoryRepository.UpdateCategory(id, category.ToModel());

            if (categoryModel is null)
            {
                return null;
            }

            return new CategoryDto(categoryModel);
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }
    }
}
