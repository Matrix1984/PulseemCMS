using MediatR;
using PulseemCMS.Application.Common.Interfaces;

namespace PulseemCMS.Application.Clients.Commands.DeleteClient;
public record DeleteClientCommand(long Id) : IRequest;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    readonly IClientDbService _clientDbService;
    public DeleteClientCommandHandler(IClientDbService clientDbService)
    {
        _clientDbService = clientDbService;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        await _clientDbService.DeleteClientsAsync(request.Id);
    }
}
