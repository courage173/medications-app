using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;

namespace Api.Models
{
    public class MedicationActiveIngredients
    {
        public int Id { get; private set; }
        public int MedicationId { get; private set; }
        public int ActiveIngredientId { get; private set; }

        public string dosage { get; private set; }

        public virtual Medication Medication { get; private set; }
        public virtual ActiveIngredient ActiveIngredient { get; private set; }

        private MedicationActiveIngredients() { }

        public MedicationActiveIngredients(CreateUpdateMedicationActiveIngredientsDto data)
        {
            MedicationId = data.MedicationId;
            ActiveIngredientId = data.ActiveIngredientId;
            this.dosage = dosage ?? throw new ArgumentNullException(nameof(dosage));
        }
    }
}