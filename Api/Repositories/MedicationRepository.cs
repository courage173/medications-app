using Api.Data;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using AutoMapper;

namespace Api.Repositories
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId)
        {
            return _context.Medications.Where(m => m.TherapeuticClassId == therapeuticClassId).ToList();
        }
    }
}

