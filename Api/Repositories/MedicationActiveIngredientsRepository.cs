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
    }
}