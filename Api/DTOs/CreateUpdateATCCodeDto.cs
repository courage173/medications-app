using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record CreateUpdateATCCodeDto
    {
        public required string code { get; set; }
    }
}