using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using Api.Services;
using Moq;
using Xunit;

namespace Api.Tests
{
    public class ActiveIngredientServiceTests
    {
        private readonly Mock<IActiveIngredientRepository> _repositoryMock;
        private readonly ActiveIngredientService _service;

        public ActiveIngredientServiceTests()
        {
            _repositoryMock = new Mock<IActiveIngredientRepository>();
            _service = new ActiveIngredientService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllActiveIngredientsAsync_ReturnsAllIngredients()
        {
            var ingredients = new List<ActiveIngredient> { new ActiveIngredient("Ingredient1"), new ActiveIngredient("Ingredient2") };
            _repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(ingredients);

            var result = await _service.GetAllActiveIngredientsAsync(1, 10);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetActiveIngredientAsync_ReturnsIngredient()
        {
            var ingredient = new ActiveIngredient("Ingredient1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(ingredient);

            var result = await _service.GetActiveIngredientAsync(1);

            Assert.Equal("Ingredient1", result.Name);
        }

        [Fact]
        public async Task AddActiveIngredientAsync_AddsIngredient()
        {
            var ingredient = new ActiveIngredient("Ingredient1");
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<ActiveIngredient>())).ReturnsAsync(ingredient);

            var result = await _service.AddActiveIngredientAsync("Ingredient1");

            Assert.Equal("Ingredient1", result.Name);
        }

        [Fact]
        public async Task UpdateActiveIngredientAsync_UpdatesIngredient()
        {
            var ingredient = new ActiveIngredient("Ingredient1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(ingredient);

            await _service.UpdateActiveIngredientAsync(1, "UpdatedIngredient");

            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<ActiveIngredient>()), Times.Once);
        }

        [Fact]
        public async Task DeleteActiveIngredientAsync_DeletesIngredient()
        {
            await _service.DeleteActiveIngredientAsync(1);

            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}