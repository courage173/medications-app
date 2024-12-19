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
    public class PharmaceuticalFormServiceTests
    {
        private readonly Mock<IPharmaceuticalFormRepository> _repositoryMock;
        private readonly PharmaceuticalFormService _service;

        public PharmaceuticalFormServiceTests()
        {
            _repositoryMock = new Mock<IPharmaceuticalFormRepository>();
            _service = new PharmaceuticalFormService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllPharmaceuticalForms_ReturnsAllForms()
        {
            var forms = new List<PharmaceuticalForm> { new PharmaceuticalForm("Form1"), new PharmaceuticalForm("Form2") };
            _repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(forms);

            var result = await _service.GetAllPharmaceuticalForms(1, 10);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPharmaceuticalForm_ReturnsForm()
        {
            var form = new PharmaceuticalForm("Form1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(form);

            var result = await _service.GetPharmaceuticalForm(1);

            Assert.Equal("Form1", result.Form);
        }

        [Fact]
        public async Task AddPharmaceuticalForm_AddsForm()
        {
            var form = new PharmaceuticalForm("Form1");
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<PharmaceuticalForm>())).ReturnsAsync(form);

            var result = await _service.AddPharmaceuticalForm("Form1");

            Assert.Equal("Form1", result.Form);
        }

        [Fact]
        public async Task UpdatePharmaceuticalForm_UpdatesForm()
        {
            var form = new PharmaceuticalForm("Form1");
            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(form);

            await _service.UpdatePharmaceuticalForm(1, "UpdatedForm");

            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<PharmaceuticalForm>()), Times.Once);
        }

        [Fact]
        public async Task DeletePharmaceuticalForm_DeletesForm()
        {
            await _service.DeletePharmaceuticalForm(1);

            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}