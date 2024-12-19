
using Api.Data;
using Api.Interfaces;
using Api.Models;

namespace Api.Repositories
{
    public class ATCCodepository : Repository<ATCCodes>, IATCCodepository
    {

        public ATCCodepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}