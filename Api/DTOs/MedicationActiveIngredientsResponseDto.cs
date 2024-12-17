using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record MedicationActiveIngredientsResponseDto
    {
        public int Id { get; set; }
        public int MedicationId { get; set; }
        public int ActiveIngredientId { get; set; }
        public string? dosage { get; set; }

        public static MedicationActiveIngredientsResponseDto FromMedicationActiveIngredients(Api.Models.MedicationActiveIngredients medicationActiveIngredients)
        {
            return new MedicationActiveIngredientsResponseDto
            {
                Id = medicationActiveIngredients.Id,
                MedicationId = medicationActiveIngredients.MedicationId,
                ActiveIngredientId = medicationActiveIngredients.ActiveIngredientId,
                dosage = medicationActiveIngredients.dosage
            };
        }
    }
}