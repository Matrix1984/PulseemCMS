using MediatR;
using PulseemCMS.Application.Common.Interfaces;
using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Application.Clients.Commands.CreateClient;
public record CreateClientCommand(long ClientId, string Cellphone, string Email, string ClientName, bool EmailStatus, bool SmsStatus) : IRequest<CreateClientVM>;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientVM>
{
    readonly IClientDbService _clientDbService;
    public CreateClientCommandHandler(IClientDbService clientDbService)
    {
        _clientDbService = clientDbService;
    }

    public async Task<CreateClientVM> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var res = new CreateClientVM(true, Array.Empty<string>());

        (Client client, int statusCode) = await _clientDbService.CreatClientAsync(request);

        if (statusCode == -1)
            return new CreateClientVM(false, new List<string>() { "Email already exists status." }); 
        else
            res.Client = client;

        return res;
    }
}
