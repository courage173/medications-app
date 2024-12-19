
using Api.Models;

namespace Api.Interfaces
{
    public interface IMedicationActiveIngredientsRepository : IRepository<MedicationActiveIngredients>
    {
        Task DeleteByMedicationId(int medicationId);
    }
}