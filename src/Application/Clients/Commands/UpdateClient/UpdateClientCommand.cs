using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JetBrains.Annotations;
using MediatR;
using PulseemCMS.Application.Clients.Commands.DeleteClient;
using PulseemCMS.Application.Common.Interfaces;

namespace PulseemCMS.Application.Clients.Commands.UpdateClient;
public record UpdateClientCommand(long ClientId, string Cellphone, string Email, string ClientName, bool EmailStatus, bool SmsStatus) : IRequest;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
{
    readonly IClientDbService _clientDbService;
    public UpdateClientCommandHandler(IClientDbService clientDbService)
    {
        _clientDbService = clientDbService;
    }

    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        await _clientDbService.UpdateClientAsync(request);
    }
}
