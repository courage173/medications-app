using Api.DTOs;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class ActiveIngredientService
    {
        private readonly IActiveIngredientRepository _repository;
        public ActiveIngredientService(IActiveIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ActiveIngredientDto>> GetAllActiveIngredientsAsync(int pageNumber, int pageSize)
        {
            var activeIngredients = await _repository.GetAllAsync(pageNumber, pageSize);
            return activeIngredients.Select(ActiveIngredientDto.FromActiveIngredient).ToList();
        }

        public async Task<ActiveIngredientDto> GetActiveIngredientAsync(int id)
        {
            var activeIngredient = await _repository.GetByIdAsync(id);
            return ActiveIngredientDto.FromActiveIngredient(activeIngredient!);
        }

        public async Task<ActiveIngredientDto> AddActiveIngredientAsync(string name)
        {
            var newActiveIngredient = new ActiveIngredient(name);
            var activeIngredient = await _repository.AddAsync(newActiveIngredient);
            return ActiveIngredientDto.FromActiveIngredient(activeIngredient);
        }

        public async Task UpdateActiveIngredientAsync(int id, string name)
        {
            var activeIngredient = await _repository.GetByIdAsync(id);
            if (activeIngredient != null)
            {
                activeIngredient = new ActiveIngredient(name);
                await _repository.UpdateAsync(activeIngredient);
            }
        }

        public async Task DeleteActiveIngredientAsync(int id) => await _repository.DeleteAsync(id);
    }
}