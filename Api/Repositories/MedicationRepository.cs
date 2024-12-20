using Api.Data;
using Api.DTOs;
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

        public async Task<MedicationListResponseDto> GetMedicationsAsync(int pageNumber, int pageSize, string? searchTerm, string? sortBy, bool ascending)
        {
            var query = _context.Medications.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(m => m.Name.Contains(searchTerm));
            }

            switch (sortBy?.ToLower())
            {
                case "name":
                    query = ascending ? query.OrderBy(m => m.Name) : query.OrderByDescending(m => m.Name);
                    break;
                case "createddate":
                    query = ascending ? query.OrderBy(m => m.CreatedAt) : query.OrderByDescending(m => m.CreatedAt);
                    break;
                default:
                    query = ascending ? query.OrderBy(m => m.Id) : query.OrderByDescending(m => m.Id);
                    break;
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var result = await query
            .Include(m => m.PharmaceuticalForm)
            .Include(m => m.ATCCodes)
            .Include(m => m.TherapeuticClass)
            .Include(m => m.MedicationActiveIngredients)
            .ThenInclude(mai => mai.ActiveIngredient)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return MedicationListResponseDto.FromMedications(result, totalItems, pageNumber);
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

