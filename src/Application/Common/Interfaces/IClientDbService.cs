using PulseemCMS.Application.Clients.Commands.CreateClient;
using PulseemCMS.Application.Clients.Commands.UpdateClient;
using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Application.Common.Interfaces;
public interface IClientDbService
{
    Task<IReadOnlyCollection<Client>> ListClientsAsync();
    Task<(Client, int)> CreatClientAsync(CreateClientCommand createClientCommand);
    Task UpdateClientAsync(UpdateClientCommand request); 
    Task DeleteClientsAsync(long id);
}
