using PulseemCMS.Domain.Common.Helpers.RegexValidators;

namespace PulseemCMS.Application.Clients.Commands.CreateClient;
public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {  
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
