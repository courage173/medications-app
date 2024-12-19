using System.Collections.Generic;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class MedicationActiveIngredientsService
    {
        private readonly IMedicationActiveIngredientsRepository _repository;

        public MedicationActiveIngredientsService(IMedicationActiveIngredientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicationActiveIngredientsResponseDto>> GetAllMedicationActiveIngredients(int pageNumber, int pageSize)
        {
            var result = await _repository.GetAllAsync(pageNumber, pageSize);
            return result.Select(MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients);
        }

        public async Task<MedicationActiveIngredientsResponseDto> GetMedicationActiveIngredient(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients(result!);
        }

        public async Task<MedicationActiveIngredientsResponseDto> AddMedicationActiveIngredient(CreateUpdateMedicationActiveIngredientsDto data)
        {
            var newMedicationActiveIngredients = new MedicationActiveIngredients(data);
            var response = await _repository.AddAsync(newMedicationActiveIngredients);

            return MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients(response);
        }

        public async Task UpdateMedicationActiveIngredient(int id, CreateUpdateMedicationActiveIngredientsDto data)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
            {
                item = new MedicationActiveIngredients(data);
                await _repository.UpdateAsync(item);
            }
        }

        public async Task DeleteByMedicationId(int medicationId) => await _repository.DeleteByMedicationId(medicationId);

        public async Task DeleteMedicationActiveIngredient(int id) => await _repository.DeleteAsync(id);
    }
}