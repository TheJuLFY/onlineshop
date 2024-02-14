namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();

        Task<ProductDto> GetProduct(Guid id);

        Task<ProductDto> InsertProduct(ProductCreateRequestDto product);

        Task<ProductDto> UpdateProduct(Guid id, ProductCreateRequestDto product);

        Task<bool> DeleteProduct(Guid id);
    }
}
