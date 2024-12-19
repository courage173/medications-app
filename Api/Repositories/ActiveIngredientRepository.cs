using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class ActiveIngredientRepository : Repository<ActiveIngredient>, IActiveIngredientRepository
    {
        public ActiveIngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}