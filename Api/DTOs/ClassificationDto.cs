using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record ClassificationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static ClassificationDto FromClassification(Api.Models.Classification classification)
        {
            return new ClassificationDto
            {
                Id = classification.Id,
                Name = classification.Name
            };
        }
    }
}