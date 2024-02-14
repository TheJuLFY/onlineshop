namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> logger;
        private ICategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            this.logger = logger;
            _categoryService = categoryService;
        }

         /// <summary>
         /// Return all Categories of AutoStore.
         /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var existingCategory = await _categoryService.GetCategories();

            logger.LogInformation("All Categories returned successfully");
            return Ok(existingCategory);
        }

        /// <summary>
        /// Return a Category by it's id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var existingCategory = await _categoryService.GetCategory(id);

            if (existingCategory is null)
            {
                logger.LogError("Category with id = \"{id}\" wasn't found and wasn't returned", id);
                return NotFound("Category not found");
            }

            logger.LogInformation("Category with id = \"{id}\" returned successfully", id);
            return Ok(existingCategory);
        }

        /// <summary>
        /// Add new Category to AutoStore.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> InsertCategory([FromBody] CategoryCreateRequestDto category)
        {
            var existingCategory = await _categoryService.InsertCategory(category);

            logger.LogInformation("New Category added successfully");
            return Ok(existingCategory);
        }

        /// <summary>
        /// Update a Category by it's id.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(Guid id, CategoryCreateRequestDto category)
        {
            var existingCategory = await _categoryService.UpdateCategory(id, category);

            if (existingCategory is null)
            {
                logger.LogError("Category with id = \"{id}\" wasn't found and wasn't updated", id);
                return NotFound("Category not found");
            }

            logger.LogInformation("Category with id = \"{id}\" updated successfully", id);
            return Ok(existingCategory);
        }

        /// <summary>
        /// Remove a Category by it's id from AutoStore.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var existingCategory = await _categoryService.DeleteCategory(id);

            if (!existingCategory)
            {
                logger.LogError("Category with id = \"{id}\" wasn't found and wasn't deleted", id);
                return NotFound("Category not found");
            }

            logger.LogInformation("Category with id = \"{id}\" deleted successfully", id);
            return Ok();
        }
    }
}
