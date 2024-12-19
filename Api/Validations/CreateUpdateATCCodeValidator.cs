using FluentValidation;
using Api.DTOs;

namespace Api.Validations
{
    public class CreateUpdateATCCodeValidator : AbstractValidator<CreateUpdateATCCodeDto>
    {
        public CreateUpdateATCCodeValidator()
        {
            RuleFor(m => m.Code).NotEmpty().WithMessage("Name is required.");
        }
    }
}