using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record CreateUpdateMedicationActiveIngredientsDto
    {
        public int MedicationId { get; set; }
        public int ActiveIngredientId { get; set; }
        public required string dosage { get; set; }
    }
}
