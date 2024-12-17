using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class PharmaceuticalFormRepository : Repository<PharmaceuticalForm>, IPharmaceuticalFormRepository
    {
        public PharmaceuticalFormRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}