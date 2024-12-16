using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PharmaceuticalForm
    {
        public int Id { get; private set; }
        public string Form { get; private set; }

        // Navigation Properties
        public ICollection<PharmaceuticalForm> MedicationPharmaceuticalForms { get; private set; } = new List<PharmaceuticalForm>();

        private PharmaceuticalForm() { } // Required for EF Core

        public PharmaceuticalForm(string form)
        {
            Form = form ?? throw new ArgumentNullException(nameof(form));
        }
    }
}