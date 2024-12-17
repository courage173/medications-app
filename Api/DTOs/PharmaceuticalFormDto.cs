using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public record PharmaceuticalFormDto
    {
        public int Id { get; set; }
        public string? Form { get; set; }

        public static PharmaceuticalFormDto FromPharmaceuticalForm(Api.Models.PharmaceuticalForm pharmaceuticalForm)
        {
            return new PharmaceuticalFormDto
            {
                Id = pharmaceuticalForm.Id,
                Form = pharmaceuticalForm.Form
            };
        }
    }
}