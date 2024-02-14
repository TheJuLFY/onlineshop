namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;

    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();

        Task<CategoryDto> GetCategory(Guid id);

        Task<CategoryDto> InsertCategory(CategoryCreateRequestDto category);

        Task<CategoryDto> UpdateCategory(Guid id, CategoryCreateRequestDto category);

        Task<bool> DeleteCategory(Guid id);
    }
}