namespace Api.DTOs
{
    public record MedicationListResponseDto
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public List<MedicationDto> Medications { get; set; } = new();


        public static MedicationListResponseDto FromMedications(List<Api.Models.Medication> medications, int total, int currentPage)
        {
            return new MedicationListResponseDto
            {
                Total = total,
                CurrentPage = currentPage,
                Medications = medications.Select(MedicationDto.FromMedication).ToList()
            };
        }
    }


    public record MedicationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompetentAuthorityStatus { get; set; }
        public string? InternalStatus { get; set; }
        public string? Unit { get; set; }
        public int PharmaceuticalFormId { get; set; }
        public string? PharmaceuticalFormName { get; set; }
        public int ATCCodeId { get; set; }
        public string? ATCCodeName { get; set; }
        public int TherapeuticClassId { get; set; }
        public string? TherapeuticClassName { get; set; }
        public string? ClassificationName { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public List<ActiveIngredientDTO> ActiveIngredients { get; set; } = new();

        public static MedicationDto FromMedication(Api.Models.Medication medication)
        {
            return new MedicationDto
            {
                Id = medication.Id,
                Name = medication.Name,
                CompetentAuthorityStatus = medication.CompetentAuthorityStatus,
                InternalStatus = medication.InternalStatus,
                Unit = medication.Unit,
                ClassificationName = medication.Classification,
                PharmaceuticalFormId = medication.PharmaceuticalFormId,
                PharmaceuticalFormName = medication.PharmaceuticalForm?.Form,
                ATCCodeId = medication.ATCCodeId,
                ATCCodeName = medication.ATCCodes?.Code,
                TherapeuticClassId = medication.TherapeuticClassId,
                TherapeuticClassName = medication.TherapeuticClass?.Name,
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
