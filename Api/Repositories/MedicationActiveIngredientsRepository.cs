using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class MedicationActiveIngredientsRepository : Repository<MedicationActiveIngredients>, IMedicationActiveIngredientsRepository
    {
        public MedicationActiveIngredientsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task DeleteByMedicationId(int medicationId)
        {
            var items = _context.MedicationActiveIngredients.Where(m => m.MedicationId == medicationId);
            _context.MedicationActiveIngredients.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}