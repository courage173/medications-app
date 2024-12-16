using System.Collections.Generic;
using Api.Models;
using Api.Repositories;

namespace Api.Services
{
    public class MedicationActiveIngredientsService
    {
        private readonly MedicationActiveIngredientsRepository _repository;

        public MedicationActiveIngredientsService(MedicationActiveIngredientsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MedicationActiveIngredients> GetAllMedicationActiveIngredients() => _repository.GetAll();

        public MedicationActiveIngredients GetMedicationActiveIngredient(int id) => _repository.GetById(id);

        public void AddMedicationActiveIngredient(MedicationActiveIngredients item) => _repository.Add(item);

        public void UpdateMedicationActiveIngredient(int id, int medicationId, int activeIngredientId, string dosage)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item = new MedicationActiveIngredients(medicationId, activeIngredientId, dosage);
                _repository.Update(item);
            }
        }

        public void DeleteMedicationActiveIngredient(int id) => _repository.Delete(id);
    }
}