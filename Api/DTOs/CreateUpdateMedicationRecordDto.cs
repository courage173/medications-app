using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record CreateUpdateMedicationRecordDto
    {
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