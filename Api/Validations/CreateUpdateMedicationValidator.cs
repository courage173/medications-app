using Api.DTOs;
using FluentValidation;

namespace Api.Validations
{
    public class CreateUpdateMedicationValidator : AbstractValidator<MedicationRecordDTO>
    {
        public CreateUpdateMedicationValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(m => m.CompetentAuthorityStatus).NotEmpty().WithMessage("Competent Authority Status is required.");
            RuleFor(m => m.InternalStatus).NotEmpty().WithMessage("Internal Status is required.");
            RuleFor(m => m.Unit).NotEmpty().WithMessage("Unit is required.");
            RuleFor(m => m.PharmaceuticalFormId).GreaterThan(0).WithMessage("Pharmaceutical Form Id must be greater than 0.");
            RuleFor(m => m.ATCCodeId).GreaterThan(0).WithMessage("ATC Code Id must be greater than 0.");
            RuleFor(m => m.TherapeuticClassId).GreaterThan(0).WithMessage("Therapeutic Class Id must be greater than 0.");
            RuleFor(m => m.ClassificationId).GreaterThan(0).WithMessage("Classification Id must be greater than 0.");
        }
    }
}