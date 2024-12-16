using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class ClassificationRepository : Repository<Classification>
    {
        public ClassificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any specific methods for ClassificationRepository here
    }
}