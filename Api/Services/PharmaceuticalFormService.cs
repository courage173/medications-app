using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class PharmaceuticalFormService
    {
        private readonly IPharmaceuticalFormRepository _repository;

        public PharmaceuticalFormService(IPharmaceuticalFormRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PharmaceuticalFormDto>> GetAllPharmaceuticalForms()
        {
            var pharmaceuticalForms = await _repository.GetAllAsync();
            return pharmaceuticalForms.Select(PharmaceuticalFormDto.FromPharmaceuticalForm);
        }

        public async Task<PharmaceuticalFormDto> GetPharmaceuticalForm(int id)
        {
            var pharmaceuticalForm = await _repository.GetByIdAsync(id);
            return PharmaceuticalFormDto.FromPharmaceuticalForm(pharmaceuticalForm!);
        }

        public async Task<PharmaceuticalFormDto> AddPharmaceuticalForm(string form)
        {
            var pharmaceuticalForm = new PharmaceuticalForm(form);
            var response = await _repository.AddAsync(pharmaceuticalForm);
            return PharmaceuticalFormDto.FromPharmaceuticalForm(response);
        }

        public async Task UpdatePharmaceuticalForm(int id, string form)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
            {
                item = new PharmaceuticalForm(form);
                await _repository.UpdateAsync(item);
            }
        }

        public async Task DeletePharmaceuticalForm(int id) => await _repository.DeleteAsync(id);
    }
}