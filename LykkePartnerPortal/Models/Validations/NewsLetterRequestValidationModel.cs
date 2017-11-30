using FluentValidation;
using LykkePartnerPortal.Models.NewsLetters;
using LykkePartnerPortal.Strings;

namespace LykkePartnerPortal.Models.Validations
{
    public class NewsletterRequestValidationModel : AbstractValidator<NewsLetterRequestModel>
    {
        public NewsletterRequestValidationModel()
        {
            RuleFor(reg => reg.Email).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
            RuleFor(reg => reg.Email).EmailAddress().WithMessage(Phrases.InvalidEmailFormat);

            RuleFor(reg => reg.Source).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
        }
    }
}