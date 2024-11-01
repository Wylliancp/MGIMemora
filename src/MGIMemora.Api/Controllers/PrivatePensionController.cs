using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Application.Handlers.PrivatePension;
using MGIMemora.Application.Queries.PrivatePension;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MGIMemora.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrivatePensionController(ILogger<PrivatePensionController> logger) : ControllerBase
{

    private readonly ILogger<PrivatePensionController> _logger = logger;

    [Route("GetTById")]
    [HttpGet]

    public async Task<IQueryResult> GetById([FromQuery] GetByIdPrivatePensionQuery query, [FromServices] PrivatePensionQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IQueryResult> GetAll([FromQuery] GetAllPrivatePensionQuery query, [FromServices] PrivatePensionQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("Create")]
    [HttpPost]

    public async Task<ICommandResult> Create([FromBody] CreatePrivatePensionCommand command, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(command);
    }

    [Route("Update")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdatePrivatePensionCommand command, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(command);
    }

    [Route("UpdateModality")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdateModalityPrivatePensionCommand command, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(command);
    }


    [Route("Delete")]
    [HttpDelete]

    public async Task<ICommandResult> Delete([FromQuery] DeletePrivatePensionCommand command, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(command);
    }
}
