using FluentValidation;
using LykkePartnerPortal.Models.Users;
using LykkePartnerPortal.Strings;

namespace LykkePartnerPortal.Models.Validations
{
    public class SingleSignOnRequestValidationModel : AbstractValidator<SingleSignOnRequestModel>
    {
        public SingleSignOnRequestValidationModel()
        {
            RuleFor(reg => reg.Code).NotNull().WithMessage(Phrases.FieldShouldNotBeEmpty);
        }
    }
}