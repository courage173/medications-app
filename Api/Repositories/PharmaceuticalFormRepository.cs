using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class PharmaceuticalFormRepository : Repository<PharmaceuticalForm>
    {
        public PharmaceuticalFormRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any specific methods for PharmaceuticalFormRepository here
    }
}