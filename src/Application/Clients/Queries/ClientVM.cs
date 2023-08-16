using PulseemCMS.Domain.Entities;

namespace PulseemCMS.Application.Clients.Queries;
public class ClientVm
{
    public IReadOnlyCollection<Client> Clients { get; set; } = Array.Empty<Client>();
}
