using Api.DTOs;
using Api.Models;

namespace Api.Models
{
    public class Medication
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CompetentAuthorityStatus { get; private set; }
        public string InternalStatus { get; private set; }
        public string Unit { get; private set; }
        public string Classification { get; private set; }

        public int PharmaceuticalFormId { get; private set; }
        public PharmaceuticalForm PharmaceuticalForm { get; private set; }

        public int ATCCodeId { get; private set; }
        public ATCCodes ATCCodes { get; private set; }

        public int TherapeuticClassId { get; private set; }
        public TherapeuticClass TherapeuticClass { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }



        public ICollection<MedicationActiveIngredients> MedicationActiveIngredients { get; private set; }

        // Parameterless constructor for EF Core
        public Medication() { }

        public Medication(CreateUpdateMedicationRecordDto medicationRecord)
        {

            Name = medicationRecord.Name!;
            CompetentAuthorityStatus = medicationRecord.CompetentAuthorityStatus!;
            InternalStatus = medicationRecord.InternalStatus!;
            Unit = medicationRecord.Unit!;
            PharmaceuticalFormId = medicationRecord.PharmaceuticalFormId;
            ATCCodeId = medicationRecord.ATCCodeId;
            TherapeuticClassId = medicationRecord.TherapeuticClassId;
            Classification = medicationRecord.Classification;

        }

        public void UpdateMedication(CreateUpdateMedicationRecordDto medicationRecord)
        {
            Name = medicationRecord.Name!;
            CompetentAuthorityStatus = medicationRecord.CompetentAuthorityStatus!;
            InternalStatus = medicationRecord.InternalStatus!;
            Unit = medicationRecord.Unit!;
            PharmaceuticalFormId = medicationRecord.PharmaceuticalFormId;
            ATCCodeId = medicationRecord.ATCCodeId;
            TherapeuticClassId = medicationRecord.TherapeuticClassId;
            Classification = medicationRecord.Classification;
        }
    }
}
