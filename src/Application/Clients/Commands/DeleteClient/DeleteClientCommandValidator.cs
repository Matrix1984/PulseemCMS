using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseemCMS.Application.Clients.Commands.DeleteClient;
public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
{
    public DeleteClientCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThanOrEqualTo(1);
    }
}
