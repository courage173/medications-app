

namespace Api.DTOs
{
    public record MedicationRecordDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CompetentAuthorityStatus { get; set; }
        public string? InternalStatus { get; set; }
        public string? Unit { get; set; }
        public string? Classification { get; set; }
        public int PharmaceuticalFormId { get; set; }
        public int ATCCodeId { get; set; }
        public int TherapeuticClassId { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        public static MedicationRecordDTO FromMedication(Api.Models.Medication medication)
        {
            return new MedicationRecordDTO
            {
                Id = medication.Id,
                Name = medication.Name,
                CompetentAuthorityStatus = medication.CompetentAuthorityStatus,
                InternalStatus = medication.InternalStatus,
                Unit = medication.Unit,
                Classification = medication.Classification,
                PharmaceuticalFormId = medication.PharmaceuticalFormId,
                ATCCodeId = medication.ATCCodeId,
                TherapeuticClassId = medication.TherapeuticClassId,

            };
        }

    }
}