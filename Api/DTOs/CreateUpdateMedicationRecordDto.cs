using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record CreateUpdateMedicationRecordDto
    {
        public string? Name { get; set; }
        public string? CompetentAuthorityStatus { get; set; }
        public string? InternalStatus { get; set; }
        public string? Unit { get; set; }
        public int PharmaceuticalFormId { get; set; }
        public int ATCCodeId { get; set; }
        public int TherapeuticClassId { get; set; }
        public int ClassificationId { get; set; }

    }
}