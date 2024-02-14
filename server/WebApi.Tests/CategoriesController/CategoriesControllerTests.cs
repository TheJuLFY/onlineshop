namespace WebApi.Tests.CategoriesController
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

    public class CategoriesControllerTests : BaseTest
    {
        [Fact]
        public async Task GetCategory_Returns_Category_With_Existing_Id()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            categoryServiceMock
                .Setup(x => x.GetCategory(categoryId))
                .ReturnsAsync(new CategoryDto(TestEntities.CategoryA));

            // Act
            var result = await sut.GetCategory(categoryId);
            var successResult = result.Result as OkObjectResult;
            var category = successResult.Value as CategoryDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(TestEntities.CategoryA.Name, category.Name);
        }

        [Fact]
        public async Task GetCategory_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            // Act
            var result = await sut.GetCategory(Guid.NewGuid());
            var errorResult = result.Result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task InsertCategory_Returns_Category_With_Correct_Data()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var categoryRequestDto = new CategoryCreateRequestDto()
            {
                Name = TestEntities.CategoryA.Name,
            };

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            categoryServiceMock
                .Setup(x => x.InsertCategory(categoryRequestDto))
                .ReturnsAsync(new CategoryDto(TestEntities.CategoryA));

            // Act
            var result = await sut.InsertCategory(categoryRequestDto);
            var successResult = result.Result as OkObjectResult;
            var category = successResult.Value as CategoryDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(categoryRequestDto.Name, category.Name);
        }

        [Fact]
        public async Task UpdateCategory_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var categoryRequestDto = new CategoryCreateRequestDto()
            {
                Name = TestEntities.CategoryA.Name,
            };

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            // Act
            var result = await sut.UpdateCategory(Guid.NewGuid(), categoryRequestDto);
            var errorResult = result.Result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task UpdateCategory_Returns_Category_With_New_Data()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var categoryRequestDto = new CategoryCreateRequestDto()
            {
                Name = TestEntities.CategoryA.Name,
            };

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            categoryServiceMock
                .Setup(x => x.UpdateCategory(categoryId, categoryRequestDto))
                .ReturnsAsync(new CategoryDto(TestEntities.CategoryA));

            // Act
            var result = await sut.UpdateCategory(categoryId, categoryRequestDto);
            var successResult = result.Result as OkObjectResult;
            var category = successResult.Value as CategoryDto;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
            Assert.Equal(categoryRequestDto.Name, category.Name);
        }

        [Fact]
        public async Task DeleteCategory_Returns_NotFound_With_NonExisting_Id()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            categoryServiceMock
                .Setup(x => x.DeleteCategory(categoryId))
                .ReturnsAsync(false);

            // Act
            var result = await sut.DeleteCategory(categoryId);
            var errorResult = result as NotFoundObjectResult;

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, errorResult.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_Removes_Category_With_Existing_Id()
        {
            // Arrange
            Guid categoryId = Guid.NewGuid();

            var loggerMock = new Mock<ILogger<Controllers.CategoriesController>>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var sut = new Controllers.CategoriesController(loggerMock.Object, categoryServiceMock.Object);

            categoryServiceMock
                .Setup(x => x.DeleteCategory(categoryId))
                .ReturnsAsync(true);

            // Act
            var result = await sut.DeleteCategory(categoryId);
            var successResult = result as OkResult;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, successResult.StatusCode);
        }
    }
}
