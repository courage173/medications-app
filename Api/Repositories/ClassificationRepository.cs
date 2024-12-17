using System.Collections.Generic;
using System.Linq;
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class ClassificationRepository : Repository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}