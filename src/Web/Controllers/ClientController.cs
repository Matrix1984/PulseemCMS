using Microsoft.AspNetCore.Mvc;
using PulseemCMS.Application.Clients.Commands.CreateClient;
using PulseemCMS.Application.Clients.Commands.DeleteClient;
using PulseemCMS.Application.Clients.Commands.UpdateClient;
using PulseemCMS.Application.Clients.Queries;

namespace PulseemCMS.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    [HttpPost]
    public async Task<ActionResult<CreateClientVM>> Create(CreateClientCommand req)
    {
        var res = await Mediator.Send(req);

        if (!res.Succeeded)
            return BadRequest(res);

        return Ok(res);
    }

    [HttpGet]
    public async Task<ActionResult<ClientVm>> GetClients()
    {
        return await Mediator.Send(new GetClientsQuery());
    }


    [HttpPut]
    public async Task<ActionResult> Update(UpdateClientCommand req)
    {
        await Mediator.Send(req);

        return NoContent();
    }


    [HttpDelete]
    public async Task<ActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteClientCommand(id));

        return NoContent();
    }
}
