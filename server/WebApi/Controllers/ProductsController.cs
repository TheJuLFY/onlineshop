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
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            this.logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Return all Products of AutoStore.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var existingProduct = await _productService.GetProducts();

            logger.LogInformation("All Products returned successfully");
            return Ok(existingProduct);
        }

        /// <summary>
        /// Return a Product by it's id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var existingProduct = await _productService.GetProduct(id);

            if (existingProduct is null)
            {
                logger.LogError("Product with id = \"{id}\" wasn't found and wasn't returned", id);
                return NotFound("Product not found");
            }

            logger.LogInformation("Category with id = \"{id}\" returned successfully", id);
            return Ok(existingProduct);
        }

        /// <summary>
        /// Add new Product to AutoStore.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> InsertProduct([FromBody] ProductCreateRequestDto product)
        {
            var existingProduct = await _productService.InsertProduct(product);

            if (existingProduct is null)
            {
                logger.LogError("New Product wasn't added");
                return NotFound("Category not found");
            }

            logger.LogInformation("New Product added successfully");
            return Ok(existingProduct);
        }

        /// <summary>
        /// Update a Product by it's id.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(Guid id, ProductCreateRequestDto product)
        {
            var existingProduct = await _productService.UpdateProduct(id, product);

            if (existingProduct is null)
            {
                logger.LogError("Product with id = \"{id}\" wasn't found and wasn't updated", id);
                return NotFound("Product not found");
            }

            logger.LogInformation("Product with id = \"{id}\" updated successfully", id);
            return Ok(existingProduct);
        }

        /// <summary>
        /// Remove a Product by it's id from AutoStore.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var existingProduct = await _productService.DeleteProduct(id);

            if (!existingProduct)
            {
                logger.LogError("Product with id = \"{id}\" wasn't found and wasn't deleted", id);
                return NotFound("Product not found");
            }

            logger.LogInformation("Product with id = \"{id}\" deleted successfully", id);
            return Ok();
        }
    }
}
