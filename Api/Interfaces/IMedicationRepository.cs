using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Models;

namespace Api.Interfaces
{
    public interface IMedicationRepository : IRepository<Medication>
    {
        Task<IEnumerable<Medication>> GetMedicationsAsync(int pageNumber, int pageSize);
        Task<Medication?> GetMedicationByIdAsync(int id);
        IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId);
    }
}