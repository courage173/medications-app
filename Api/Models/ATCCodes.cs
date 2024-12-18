
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
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