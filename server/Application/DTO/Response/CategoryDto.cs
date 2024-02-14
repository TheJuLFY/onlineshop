namespace Application.DTO.Response
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;

    public class CategoryDto
    {
        public CategoryDto(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Description = category.Description;
            this.ImageUrl = category.ImageUrl;
            this.Products = ConvertProduct(category.Products);
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public List<ProductDto> Products { get; set; }

        private static List<ProductDto> ConvertProduct(List<Product> products)
        {
            if (products == null)
            {
                return null;
            }

            var productsDto = new List<ProductDto>();

            foreach (Product product in products)
            {
                product.Category = null;
                productsDto.Add(new ProductDto(product));
            }

            return productsDto;
        }
    }
}
