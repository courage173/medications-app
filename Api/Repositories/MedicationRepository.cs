using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Medication>> GetMedicationsAsync(int pageNumber, int pageSize)
        {
            Console.WriteLine("Getting medications");
            var result = await _context.Medications
                .Include(m => m.PharmaceuticalForm)
                .Include(m => m.ATCCodes)
                .Include(m => m.TherapeuticClass)
                .Include(m => m.Classification)
                .Include(m => m.MedicationActiveIngredients)
                .ThenInclude(mai => mai.ActiveIngredient)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            Console.WriteLine(result.ToArray());

            Console.WriteLine();
            return result;
        }

        public async Task<Medication?> GetMedicationByIdAsync(int id)
        {
            return await _context.Medications
                .Include(m => m.PharmaceuticalForm)
                .Include(m => m.ATCCodes)
                .Include(m => m.TherapeuticClass)
                .Include(m => m.Classification)
                .Include(m => m.MedicationActiveIngredients)
                .FirstOrDefaultAsync(m => m.Id == id);
        }



        public IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId)
        {
            return _context.Medications.Where(m => m.TherapeuticClassId == therapeuticClassId).Include(m => m.ATCCodeId).ThenInclude(m => m).ToList();
        }
    }
}

