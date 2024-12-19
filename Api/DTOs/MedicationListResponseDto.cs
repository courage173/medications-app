namespace Api.DTOs
{
    public record MedicationListResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompetentAuthorityStatus { get; set; }
        public string? InternalStatus { get; set; }
        public string? Unit { get; set; }
        public int PharmaceuticalFormId { get; set; }
        public string? PharmaceuticalFormName { get; set; } // Added related entity field
        public int ATCCodeId { get; set; }
        public string? ATCCodeName { get; set; } // Added related entity field
        public int TherapeuticClassId { get; set; }
        public string? TherapeuticClassName { get; set; } // Added related entity field
        public int ClassificationId { get; set; }
        public string? ClassificationName { get; set; } // Added related entity field

        public List<ActiveIngredientDTO> ActiveIngredients { get; set; } = new(); // Added related collection

        public static MedicationListResponseDto FromMedication(Api.Models.Medication medication)
        {
            return new MedicationListResponseDto
            {
                Id = medication.Id,
                Name = medication.Name,
                CompetentAuthorityStatus = medication.CompetentAuthorityStatus,
                InternalStatus = medication.InternalStatus,
                Unit = medication.Unit,
                PharmaceuticalFormId = medication.PharmaceuticalFormId,
                PharmaceuticalFormName = medication.PharmaceuticalForm?.Form,
                ATCCodeId = medication.ATCCodeId,
                ATCCodeName = medication.ATCCodes?.Code,
                TherapeuticClassId = medication.TherapeuticClassId,
                TherapeuticClassName = medication.TherapeuticClass?.Name,
                ClassificationId = medication.ClassificationId,
                ClassificationName = medication.Classification?.Name,
                ActiveIngredients = medication.MedicationActiveIngredients?
                    .Select(mai => ActiveIngredientDTO.FromMedicationActiveIngredient(mai))
                    .ToList() ?? new List<ActiveIngredientDTO>()
            };
        }
    }

    public record ActiveIngredientDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dosage { get; set; }

        public static ActiveIngredientDTO FromMedicationActiveIngredient(Api.Models.MedicationActiveIngredients mai)
        {
            return new ActiveIngredientDTO
            {
                Id = mai.ActiveIngredientId,
                Name = mai.ActiveIngredient?.Name,
                Dosage = mai.Dosage
            };
        }
    }
}