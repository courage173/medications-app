using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class TherapeuticClassRepository : Repository<TherapeuticClass>
    {
        public TherapeuticClassRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any specific methods for TherapeuticClassRepository here
    }
}