using FluentValidation;
using LykkePartnerPortal.Models.Partners;
using LykkePartnerPortal.Strings;

namespace LykkePartnerPortal.Models.Validations
{
    public class PartnerRequestValidationModel : AbstractValidator<PartnerRequestModel>
    {
        public PartnerRequestValidationModel()
        {
            RuleFor(reg => reg.Email).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.Email).EmailAddress().WithMessage(Phrases.InvalidEmailFormat);

            RuleFor(reg => reg.FirstName).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.FirstName).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);

            RuleFor(reg => reg.LastName).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.LastName).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);

            RuleFor(reg => reg.ProposalConcern).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.ProposalConcern).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);

            RuleFor(reg => reg.Description).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.Description).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);
        }
    }
}
