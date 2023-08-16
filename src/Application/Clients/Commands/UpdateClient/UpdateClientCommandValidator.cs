using PulseemCMS.Domain.Common.Helpers.RegexValidators;

namespace PulseemCMS.Application.Clients.Commands.UpdateClient;
public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(v => v.ClientId)
            .GreaterThanOrEqualTo(1);

        RuleFor(v => v.Cellphone)
         .Matches(RegexValidatorHelper.PHONE_NUMBER_REG_VALIDATOR)
         .NotEmpty();

        RuleFor(v => v.Email)
         .EmailAddress()
         .MinimumLength(1)
         .MaximumLength(500)
         .NotEmpty();

        RuleFor(v => v.ClientName)
         .Matches(RegexValidatorHelper.NAME_REG_VALIDATOR)
         .NotEmpty();
    }
}
