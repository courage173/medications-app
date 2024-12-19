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
    public class MedicationActiveIngredientsServiceTests
    {
        private readonly Mock<IMedicationActiveIngredientsRepository> _repositoryMock;
        private readonly MedicationActiveIngredientsService _service;

        public MedicationActiveIngredientsServiceTests()
        {
            _repositoryMock = new Mock<IMedicationActiveIngredientsRepository>();
            _service = new MedicationActiveIngredientsService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllMedicationActiveIngredients_ReturnsAllIngredients()
        {

            var ingredients = new List<MedicationActiveIngredients>
            {
                new MedicationActiveIngredients(new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" }),
                new MedicationActiveIngredients(new CreateUpdateMedicationActiveIngredientsDto { dosage = "20mg" })
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(ingredients);

            var result = await _service.GetAllMedicationActiveIngredients(1, 10);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetMedicationActiveIngredient_ReturnsIngredient()
        {

            var ingredient = new MedicationActiveIngredients(new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" });
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(ingredient);

            var result = await _service.GetMedicationActiveIngredient(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddMedicationActiveIngredient_AddsIngredient()
        {

            var ingredient = new MedicationActiveIngredients(new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" });
            var dto = new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" };
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<MedicationActiveIngredients>())).ReturnsAsync(ingredient);

            var result = await _service.AddMedicationActiveIngredient(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateMedicationActiveIngredient_UpdatesIngredient()
        {

            var ingredient = new MedicationActiveIngredients(new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" });
            var dto = new CreateUpdateMedicationActiveIngredientsDto { dosage = "10mg" };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(ingredient);

            await _service.UpdateMedicationActiveIngredient(1, dto);

            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<MedicationActiveIngredients>()), Times.Once);
        }

        [Fact]
        public async Task DeleteMedicationActiveIngredient_DeletesIngredient()
        {
            await _service.DeleteMedicationActiveIngredient(1);

            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task DeleteByMedicationId_DeletesIngredientsByMedicationId()
        {
            await _service.DeleteByMedicationId(1);

            _repositoryMock.Verify(repo => repo.DeleteByMedicationId(It.IsAny<int>()), Times.Once);
        }
    }
}