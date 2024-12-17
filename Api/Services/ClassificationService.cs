
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using System.Linq;

namespace Api.Services
{
    public class ClassificationService
    {

        private readonly IClassificationRepository _repository;

        public ClassificationService(IClassificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClassificationDto>> GetAllClassificationsAsync()
        {
            var classifications = await _repository.GetAllAsync();
            return classifications.Select(ClassificationDto.FromClassification).ToList();
        }

        public async Task<ClassificationDto> GetClassificationAsync(int id)
        {
            var classification = await _repository.GetByIdAsync(id);
            return ClassificationDto.FromClassification(classification!);
        }

        public async Task<ClassificationDto> AddClassificationAsync(string name)
        {
            var newClassification = new Classification(name);
            var classification = await _repository.AddAsync(newClassification);
            return ClassificationDto.FromClassification(classification);
        }

        public async Task UpdateClassificationAsync(int id, string name)
        {
            var classification = await _repository.GetByIdAsync(id);
            if (classification != null)
            {
                classification.UpdateClassification(name);
                await _repository.UpdateAsync(classification);
            }
        }

        public async Task DeleteClassificationAsync(int id) => await _repository.DeleteAsync(id);
    }
}