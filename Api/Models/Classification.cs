using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Classification
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Classification() { } // Required for EF Core

        public Classification(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void UpdateClassification(string name)

        {

            Name = name ?? throw new ArgumentNullException(nameof(name));

        }
    }
}