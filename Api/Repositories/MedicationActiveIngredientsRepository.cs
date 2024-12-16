using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class MedicationActiveIngredientsRepository : Repository<MedicationActiveIngredients>
    {
        public MedicationActiveIngredientsRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any specific methods for MedicationActiveIngredientsRepository here
    }
}