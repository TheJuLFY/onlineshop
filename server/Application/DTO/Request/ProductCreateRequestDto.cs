namespace Application.DTO.Request
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Constants;
    using Domain.Models;

    public class ProductCreateRequestDto : IDtoMapper<Product>
    {
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Range(500000, 50000000)]
        public decimal Price { get; set; }

        [Range(0.5, 500)]
        public decimal Tonnage { get; set; }

        [Range(0, 2)]
        public Region Region { get; set; }

        public Product ToModel()
        {
            return new Product()
            {
                CategoryId = this.CategoryId,
                Name = this.Name,
                Description = this.Description,
                ImageUrl = this.ImageUrl,
                Price = this.Price,
                Tonnage = this.Tonnage,
                Region = this.Region,
            };
        }
    }
}
