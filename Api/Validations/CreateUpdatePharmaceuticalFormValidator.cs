
using Api.DTOs;
using FluentValidation;

namespace Api.Validations
{
    public class CreateUpdatePharmaceuticalFormValidator : AbstractValidator<CreateUpdatePharmaceuticalFormDto>
    {
        public CreateUpdatePharmaceuticalFormValidator()
        {
            RuleFor(m => m.Form).NotEmpty().WithMessage("Name is required.");
        }
    }
}