namespace PulseemCMS.Application.Clients.Commands.CreateClient;
public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(v => v.ClientId)
            .GreaterThanOrEqualTo(1);

        RuleFor(v => v.Cellphone)
          .MinimumLength(10)
          .MaximumLength(12)
         .NotEmpty();

        RuleFor(v => v.Email)
         .MinimumLength(1)
          .MaximumLength(500)
         .NotEmpty();

        RuleFor(v => v.ClientName)
         .MinimumLength(1)
         .MaximumLength(100)
         .NotEmpty();
    }
}
