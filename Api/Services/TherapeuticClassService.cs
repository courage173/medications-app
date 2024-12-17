using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class TherapeuticClassService
    {
        private readonly ITherapeuticClassRepository _repository;

        public TherapeuticClassService(ITherapeuticClassRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TherapeuticClassDto>> GetAllTherapeuticClasses()
        {
            var therapeuticClasses = await _repository.GetAllAsync();
            return therapeuticClasses.Select(TherapeuticClassDto.FromTherapeuticClass);
        }

        public async Task<TherapeuticClassDto> GetTherapeuticClass(int id)
        {
            var therapeuticClass = await _repository.GetByIdAsync(id);
            return TherapeuticClassDto.FromTherapeuticClass(therapeuticClass!);
        }

        public async Task<TherapeuticClassDto> AddTherapeuticClass(string name)
        {
            var therapeuticClass = new TherapeuticClass(name);
            var response = await _repository.AddAsync(therapeuticClass);
            return TherapeuticClassDto.FromTherapeuticClass(response);
        }

        public async Task UpdateTherapeuticClass(int id, string name)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
            {
                item = new TherapeuticClass(name);
                await _repository.UpdateAsync(item);
            }
        }

        public async Task DeleteTherapeuticClass(int id) => await _repository.DeleteAsync(id);
    }
}