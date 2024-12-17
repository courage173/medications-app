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
        IEnumerable<Medication> GetMedicationsByTherapeuticClass(int therapeuticClassId);
    }
}