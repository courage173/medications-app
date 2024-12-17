
using Api.DTOs;
using FluentValidation;

namespace Api.Validations
{
    public class UpdateMedicationValidator : AbstractValidator<MedicationRecordDTO>
    {

        // Add the validation logic here

        public UpdateMedicationValidator()
        {
            RuleFor(m => m.Name)
             .NotEmpty()
             .When(m => m.Name != null)
             .WithMessage("Name is required.");

            RuleFor(m => m.CompetentAuthorityStatus)
                .NotEmpty()
                .When(m => m.CompetentAuthorityStatus != null)
                .WithMessage("Competent Authority Status is required.");

            RuleFor(m => m.InternalStatus)
                .NotEmpty()
                .When(m => m.InternalStatus != null)
                .WithMessage("Internal Status is required.");

            RuleFor(m => m.Unit)
                .NotEmpty()
                .When(m => m.Unit != null)
                .WithMessage("Unit is required.");

            RuleFor(m => m.PharmaceuticalFormId)
                .GreaterThan(0)
                .When(m => m.PharmaceuticalFormId != null)
                .WithMessage("Pharmaceutical Form Id must be greater than 0.");

            RuleFor(m => m.ATCCodeId)
                .GreaterThan(0)
                .When(m => m.ATCCodeId != null)
                .WithMessage("ATC Code Id must be greater than 0.");

            RuleFor(m => m.TherapeuticClassId)
                .GreaterThan(0)
                .When(m => m.TherapeuticClassId != null)
                .WithMessage("Therapeutic Class Id must be greater than 0.");

            RuleFor(m => m.ClassificationId)
                .GreaterThan(0)
                .When(m => m.ClassificationId != null);
        }
    }
}