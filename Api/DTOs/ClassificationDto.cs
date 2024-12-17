using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record ClassificationDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}