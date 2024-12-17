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

        public IEnumerable<MedicationActiveIngredientsResponseDto> GetAllMedicationActiveIngredients() => _repository.GetAll().Select(MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients);

        public MedicationActiveIngredientsResponseDto GetMedicationActiveIngredient(int id) => MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients(_repository.GetById(id));

        public MedicationActiveIngredientsResponseDto AddMedicationActiveIngredient(CreateUpdateMedicationActiveIngredientsDto data)
        {
            var newMedicationActiveIngredients = new MedicationActiveIngredients(data);
            var response = _repository.Add(newMedicationActiveIngredients);

            return MedicationActiveIngredientsResponseDto.FromMedicationActiveIngredients(response);
        }

        public void UpdateMedicationActiveIngredient(int id, CreateUpdateMedicationActiveIngredientsDto data)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item = new MedicationActiveIngredients(data);
                _repository.Update(item);
            }
        }

        public void DeleteMedicationActiveIngredient(int id) => _repository.Delete(id);
    }
}