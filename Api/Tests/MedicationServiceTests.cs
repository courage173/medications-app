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
    public class MedicationServiceTests
    {
        private readonly Mock<IMedicationRepository> _medicationRepositoryMock;
        private readonly Mock<MedicationActiveIngredientsService> _activeIngredientServiceMock;
        private readonly MedicationService _service;

        public MedicationServiceTests()
        {
            _medicationRepositoryMock = new Mock<IMedicationRepository>();
            _activeIngredientServiceMock = new Mock<MedicationActiveIngredientsService>(null);
            _service = new MedicationService(_medicationRepositoryMock.Object, _activeIngredientServiceMock.Object);
        }

        [Fact]
        public async Task GetAllMedications_ReturnsAllMedications()
        {
            // Arrange
            var medications = new List<Medication>
    {
        new Medication(new CreateUpdateMedicationRecordDto()),
        new Medication(new CreateUpdateMedicationRecordDto())
    };

            var expectedResponse = MedicationListResponseDto.FromMedications(medications, total: 2, currentPage: 1);

            _medicationRepositoryMock
                .Setup(repo => repo.GetMedicationsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<bool>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _service.GetAllMedications(1, 10, null, null, false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Total);
            Assert.Equal(1, result.CurrentPage);
            Assert.Equal(2, result.Medications.Count);
        }

        [Fact]
        public async Task GetMedication_ReturnsMedication()
        {
            // Arrange
            var medicationDto = new CreateUpdateMedicationRecordDto();
            var medication = new Medication(medicationDto);
            _medicationRepositoryMock.Setup(repo => repo.GetMedicationByIdAsync(It.IsAny<int>())).ReturnsAsync(medication);

            var result = await _service.GetMedication(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddMedication_AddsMedication()
        {
            // Arrange
            var medicationDto = new CreateUpdateMedicationRecordDto();
            var medication = new Medication(medicationDto);
            _medicationRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Medication>())).ReturnsAsync(medication);

            await _service.AddMedication(medicationDto);

            _medicationRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Medication>()), Times.Once);
        }

        [Fact]
        public async Task DeleteMedication_DeletesMedication()
        {
            await _service.DeleteMedication(1);

            _medicationRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}