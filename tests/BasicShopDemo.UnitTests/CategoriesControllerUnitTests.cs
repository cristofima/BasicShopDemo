using BasicShopDemo.Api.Controllers;
using BasicShopDemo.Api.Core.Interfaces.DAO;
using BasicShopDemo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace BasicShopDemo.UnitTests
{
    public class CategoriesControllerUnitTests
    {
        private readonly Mock<ICategoryDAO> mockCategoryDAO;
        private readonly CategoriesController categoriesController;


        public CategoriesControllerUnitTests()
        {
            mockCategoryDAO = new Mock<ICategoryDAO>();
            categoriesController = new CategoriesController(mockCategoryDAO.Object);
        }

        [Fact]
        public void GetCategoryShouldBeOfTypeOkObjectResult()
        {
            // Arrange
            mockCategoryDAO.Setup(svc => svc.GetAll(null))
            .Returns(new List<Category>());

            // Act
            var result = categoriesController.GetCategory(null);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);

            Assert.IsAssignableFrom<IEnumerable<Category>>(viewResult.Value);
        }
    }
}
