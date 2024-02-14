namespace Application.DTO.Response
{
    using System;
    using Domain.Constants;
    using Domain.Models;

    public class ProductDto
    {
        public ProductDto(Product product)
        {
            this.Id = product.Id;
            this.CategoryId = product.CategoryId;
            this.Name = product.Name;
            this.Description = product.Description;
            this.ImageUrl = product.ImageUrl;
            this.Price = product.Price;
            this.Tonnage = product.Tonnage;
            this.Region = product.Region;
            this.Category = ConvertCategory(product.Category);
        }

        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal Tonnage { get; set; }

        public Region Region { get; set; }

        public CategoryDto Category { get; set; }

        private static CategoryDto ConvertCategory(Category category)
        {
            if (category == null)
            {
                return null;
            }

            return new CategoryDto(category);
        }
    }
}
