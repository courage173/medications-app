using FluentValidation;
using Api.DTOs;

namespace Api.Validations
{
    public class CreateUpdateClassificationValidator : AbstractValidator<CreateAndUpdateClassificationDto>
    {
        public CreateUpdateClassificationValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required.");
        }
    }
}