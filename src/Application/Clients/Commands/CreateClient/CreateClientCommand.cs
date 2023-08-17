using System;
using FluentValidation.Results;
using MediatR;
using PulseemCMS.Application.Common.Interfaces;
using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Application.Clients.Commands.CreateClient;
public record CreateClientCommand(string Cellphone, string Email, string ClientName) : IRequest<CreateClientVM>;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientVM>
{
    readonly IClientDbService _clientDbService;

    readonly IValidator<CreateClientCommand> _validator;

    public CreateClientCommandHandler(IValidator<CreateClientCommand> validator, IClientDbService clientDbService)
    {
        _clientDbService = clientDbService;

        _validator = validator;
    }

    public async Task<CreateClientVM> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var res = new CreateClientVM(true, Array.Empty<string>());

        ValidationResult? result = await _validator.ValidateAsync(request);

        if (!result.IsValid)
        { }

        (Client client, int statusCode) = await _clientDbService.CreatClientAsync(request);

        if (statusCode == -1)
            return new CreateClientVM(false, new List<string>() { "Email already exists status." });
        else
            res.Client = client;

        return res;
    }
}
