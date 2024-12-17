using Api.DTOs;
using FluentValidation;

namespace Api.Validations
{
    public class CreateUpdateTherapeuticValidator : AbstractValidator<CreateUpdateTherapeuticClassDto>
    {
        public CreateUpdateTherapeuticValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}