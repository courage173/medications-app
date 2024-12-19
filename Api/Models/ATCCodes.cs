
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class ATCCodes
    {
        public int Id { get; private set; }
        public string Code { get; private set; }

        private ATCCodes() { }

        public ATCCodes(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}