using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class TherapeuticClassRepository : Repository<TherapeuticClass>, ITherapeuticClassRepository
    {
        public TherapeuticClassRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}