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

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var productsModel = await _productRepository.GetProducts();

            foreach (Product product in productsModel)
            {
                product.Category.Products = null;
            }

            var entity = productsModel.Select(x => new ProductDto(x)).ToList();

            return entity;
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            var productModel = await _productRepository.GetProduct(id);

            if (productModel is null)
            {
                return null;
            }

            productModel.Category.Products = null;

            return new ProductDto(productModel);
        }

        public async Task<ProductDto> InsertProduct(ProductCreateRequestDto product)
        {
            if (product.CategoryId == Guid.Empty)
            {
                return null;
            }

            var categoryModel = await _categoryRepository.GetCategory(product.CategoryId);

            if (categoryModel is null)
            {
                return null;
            }

            var productModel = await _productRepository.InsertProduct(product.ToModel());

            return new ProductDto(productModel);
        }

        public async Task<ProductDto> UpdateProduct(Guid id, ProductCreateRequestDto product)
        {
            if (product.CategoryId == Guid.Empty)
            {
                return null;
            }

            var categoryModel = await _categoryRepository.GetCategory(product.CategoryId);

            if (categoryModel is null)
            {
                return null;
            }

            var productModel = await _productRepository.UpdateProduct(id, product.ToModel());

            if (productModel is null)
            {
                return null;
            }

            return new ProductDto(productModel);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
