using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;

namespace Api.Repositories
{
    public class MedicationRepository : Repository<Medication>
    {
        public MedicationRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any specific methods for MedicationRepository here
        public IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId)
        {
            return _context.Medications.Where(m => m.TherapeuticClassId == therapeuticClassId).ToList();
        }
    }
}

