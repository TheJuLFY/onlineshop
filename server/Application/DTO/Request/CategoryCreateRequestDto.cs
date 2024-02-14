namespace Application.DTO.Request
{
    using System.ComponentModel.DataAnnotations;
    using Application.Interfaces;
    using Domain.Models;

    public class CategoryCreateRequestDto : IDtoMapper<Category>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Category ToModel()
        {
            return new Category()
            {
                Name = this.Name,
                Description = this.Description,
                ImageUrl = this.ImageUrl,
            };
        }
    }
}