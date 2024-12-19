using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record ActiveIngredientDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        public static ActiveIngredientDto FromActiveIngredient(Api.Models.ActiveIngredient activeIngredient)
        {
            return new ActiveIngredientDto
            {
                Id = activeIngredient.Id,
                Name = activeIngredient.Name
            };
        }
    }
}