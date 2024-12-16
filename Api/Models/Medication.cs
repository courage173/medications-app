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

        public int PharmaceuticalFormId { get; private set; }
        public PharmaceuticalForm PharmaceuticalForm { get; private set; }

        public int ATCCodeId { get; private set; }
        public ATCCodes ATCCodes { get; private set; }

        public int TherapeuticClassId { get; private set; }
        public TherapeuticClass TherapeuticClass { get; private set; }

        public int ClassificationId { get; private set; }
        public Classification Classification { get; private set; }

        public ICollection<MedicationActiveIngredients> MedicationActiveIngredients { get; private set; }

        private Medication() { }

        public Medication(string name,
                string competentAuthorityStatus, string internalStatus, string unit, int pharmaceuticalFormId, int atcCodeId, int therapeuticClassId, int classificationId)
        {

            Name = name;
            CompetentAuthorityStatus = competentAuthorityStatus;
            InternalStatus = internalStatus;
            Unit = unit;
            PharmaceuticalFormId = pharmaceuticalFormId;
            TherapeuticClassId = therapeuticClassId;
            ClassificationId = classificationId;
            ATCCodeId = atcCodeId;

        }

        public void UpdateMedication(string name, string competentAuthorityStatus, string internalStatus, string unit, int pharmaceuticalFormId, int atcCodeId, int therapeuticClassId, int classificationId)
        {
            Name = name;
            CompetentAuthorityStatus = competentAuthorityStatus;
            InternalStatus = internalStatus;
            Unit = unit;
            PharmaceuticalFormId = pharmaceuticalFormId;
            ATCCodeId = atcCodeId;
            TherapeuticClassId = therapeuticClassId;
            ClassificationId = classificationId;
        }
    }
}
