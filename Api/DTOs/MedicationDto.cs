

namespace Api.DTOs
{
    public record MedicationRecordDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CompetentAuthorityStatus { get; set; }
        public required string InternalStatus { get; set; }
        public required string Unit { get; set; }
        public int PharmaceuticalFormId { get; set; }
        public int ATCCodeId { get; set; }
        public int TherapeuticClassId { get; set; }
        public int ClassificationId { get; set; }
    }
}