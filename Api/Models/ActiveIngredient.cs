using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ActiveIngredient
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<ActiveIngredient> MedicationActiveIngredients { get; private set; } = new List<ActiveIngredient>();


        public ActiveIngredient(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        // get all active ingredients
        public IReadOnlyCollection<ActiveIngredient> GetActiveIngredients()
        {
            return MedicationActiveIngredients.ToList().AsReadOnly();
        }

    }
}