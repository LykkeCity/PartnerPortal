using FluentValidation;
using LykkePartnerPortal.Models.Contacts;
using LykkePartnerPortal.Strings;

namespace LykkePartnerPortal.Models.Validations
{
    public class ContactRequestValidationModel : AbstractValidator<ContactRequestModel>
    {
        public ContactRequestValidationModel()
        {
            RuleFor(reg => reg.Email).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.Email).EmailAddress().WithMessage(Phrases.InvalidEmailFormat);

            RuleFor(reg => reg.Source).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.Source).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);

            RuleFor(reg => reg.FullName).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.FullName).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);

            RuleFor(reg => reg.PhoneNumber).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.PhoneNumber).NotEmpty().WithMessage(Phrases.FieldShouldNotBeEmpty);
        }
    }
}
