namespace Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Constants;

    public class Product
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(3, 1)")]
        public decimal Tonnage { get; set; }

        public Region Region { get; set; }

        public Category Category { get; set; }
    }
}
