using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ATCCodes
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private ATCCodes() { }

        public ATCCodes(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}