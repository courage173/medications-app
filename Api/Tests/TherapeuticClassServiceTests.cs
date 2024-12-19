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
    public class TherapeuticClassServiceTests
    {
        private readonly Mock<ITherapeuticClassRepository> _repositoryMock;
        private readonly TherapeuticClassService _service;

        public TherapeuticClassServiceTests()
        {
            _repositoryMock = new Mock<ITherapeuticClassRepository>();
            _service = new TherapeuticClassService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllTherapeuticClasses_ReturnsAllClasses()
        {
            var classes = new List<TherapeuticClass> { new TherapeuticClass("Class1"), new TherapeuticClass("Class2") };
            _repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(classes);

            var result = await _service.GetAllTherapeuticClasses(1, 10);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetTherapeuticClass_ReturnsClass()
        {
            var therapeuticClass = new TherapeuticClass("Class1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(therapeuticClass);

            var result = await _service.GetTherapeuticClass(1);

            Assert.Equal("Class1", result.Name);
        }

        [Fact]
        public async Task AddTherapeuticClass_AddsClass()
        {
            var therapeuticClass = new TherapeuticClass("Class1");
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<TherapeuticClass>())).ReturnsAsync(therapeuticClass);

            var result = await _service.AddTherapeuticClass("Class1");

            Assert.Equal("Class1", result.Name);
        }

        [Fact]
        public async Task UpdateTherapeuticClass_UpdatesClass()
        {
            var therapeuticClass = new TherapeuticClass("Class1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(therapeuticClass);

            await _service.UpdateTherapeuticClass(1, "UpdatedClass");

            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<TherapeuticClass>()), Times.Once);
        }

        [Fact]
        public async Task DeleteTherapeuticClass_DeletesClass()
        {
            await _service.DeleteTherapeuticClass(1);

            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}