using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class TherapeuticClassDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public static TherapeuticClassDto FromTherapeuticClass(Api.Models.TherapeuticClass therapeuticClass)
        {
            return new TherapeuticClassDto
            {
                Id = therapeuticClass.Id,
                Name = therapeuticClass.Name
            };
        }
    }
}