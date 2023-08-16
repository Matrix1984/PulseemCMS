using MediatR;
using PulseemCMS.Application.Common.Interfaces;

namespace PulseemCMS.Application.Clients.Queries;
public record GetClientsQuery : IRequest<ClientVm>;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, ClientVm>
{
    readonly IClientDbService _clientDbService;
    public GetClientsQueryHandler(IClientDbService clientDbService)
    {
        _clientDbService = clientDbService;
    }

    public async Task<ClientVm> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var resVm = new ClientVm();

        resVm.Clients = await _clientDbService.ListClientsAsync();

        return resVm;
    }
}
