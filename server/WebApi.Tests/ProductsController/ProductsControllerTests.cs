namespace WebApi.Tests.ProductsController
{
    using System;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.DTO.Response;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using WebAPI.MockFactory.Tests.Data;
    using Xunit;

    public class ProductsControllerTests : BaseTest
    {
        [Fact]
        public async Task GetProduct_Returns_Product_With_Existing_Id()
        {
            // Arrange
            Guid productId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.GetProduct(productId))
                .ReturnsAsync(new ProductDto(TestEntities.ProductA));

            // Act
            var result = await sut.GetProduct(productId);
            var successResult = result.Result as OkObjectResult;
            var product = successResult.Value as ProductDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(TestEntities.ProductA.Name, product.Name);
        }

        [Fact]
        public async Task GetProduct_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            Guid productId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.GetProduct(productId))
                .ReturnsAsync(new ProductDto(TestEntities.ProductA));

            // Act
            var result = await sut.GetProduct(Guid.NewGuid());
            var errorResult = result.Result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task InsertProduct_Returns_Product_With_Correct_Data()
        {
            // Arrange
            Guid productId = Guid.NewGuid();
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var productRequestDto = new ProductCreateRequestDto()
            {
                CategoryId = categoryId,
                Name = TestEntities.ProductA.Name,
                Price = TestEntities.ProductA.Price,
                Tonnage = TestEntities.ProductA.Tonnage,
            };

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.InsertProduct(productRequestDto))
                .ReturnsAsync(new ProductDto(TestEntities.ProductA));

            // Act
            var result = await sut.InsertProduct(productRequestDto);
            var successResult = result.Result as OkObjectResult;
            var product = successResult.Value as ProductDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(productRequestDto.Name, product.Name);
            Assert.Equal(productRequestDto.Price, product.Price);
            Assert.Equal(productRequestDto.Tonnage, product.Tonnage);
        }

        [Fact]
        public async Task UpdateProduct_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            Guid productId = Guid.NewGuid();
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var productRequestDto = new ProductCreateRequestDto()
            {
                CategoryId = categoryId,
                Name = TestEntities.ProductA.Name,
                Price = TestEntities.ProductA.Price,
                Tonnage = TestEntities.ProductA.Tonnage,
            };

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.UpdateProduct(productId, productRequestDto))
                .ReturnsAsync(new ProductDto(TestEntities.ProductA));

            // Act
            var result = await sut.UpdateProduct(Guid.NewGuid(), productRequestDto);
            var errorResult = result.Result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_Returns_Product_With_New_Data()
        {
            // Arrange
            Guid productId = Guid.NewGuid();
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var productRequestDto = new ProductCreateRequestDto()
            {
                CategoryId = categoryId,
                Name = TestEntities.ProductA.Name,
                Price = TestEntities.ProductA.Price,
                Tonnage = TestEntities.ProductA.Tonnage,
            };

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.UpdateProduct(productId, productRequestDto))
                .ReturnsAsync(new ProductDto(TestEntities.ProductA));

            // Act
            var result = await sut.UpdateProduct(productId, productRequestDto);
            var successResult = result.Result as OkObjectResult;
            var product = successResult.Value as ProductDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(productRequestDto.Name, product.Name);
            Assert.Equal(productRequestDto.Price, product.Price);
            Assert.Equal(productRequestDto.Tonnage, product.Tonnage);
        }

        [Fact]
        public async Task DeleteProduct_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            Guid productId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.DeleteProduct(productId))
                .ReturnsAsync(false);

            // Act
            var result = await sut.DeleteProduct(productId);
            var errorResult = result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task DeleteProduct_Removes_Product_With_Existing_Id()
        {
            // Arrange
            Guid productId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.ProductsController>>();
            var productServiceMock = new Mock<IProductService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.ProductsController(loggerMock.Object, productServiceMock.Object);

            productServiceMock
                .Setup(x => x.DeleteProduct(productId))
                .ReturnsAsync(true);

            // Act
            var result = await sut.DeleteProduct(productId);
            var successResult = result as OkResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
        }
    }
}
