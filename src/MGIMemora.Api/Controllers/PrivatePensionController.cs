using MGIMemora.Application.Commands.PrivatePension;
using MGIMemora.Application.Handlers;
using MGIMemora.Application.Queries.PrivatePension;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MGIMemora.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrivatePensionController : ControllerBase
{

    private readonly ILogger<PrivatePensionController> _logger;

    public PrivatePensionController(ILogger<PrivatePensionController> logger)
    {
        _logger = logger;
    }

    [Route("GetTById")]
    [HttpGet]

    public async Task<IQueryResult> GetById([FromQuery] GetByIdQuery query, [FromServices] PrivatePensionQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IQueryResult> GetAll([FromQuery] GetAllQuery query, [FromServices] PrivatePensionQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("Create")]
    [HttpPost]

    public async Task<ICommandResult> Create([FromBody] CreatePrivatePensionCommand createPrivatePensionCommand, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(createPrivatePensionCommand);
    }

    [Route("Update")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdatePrivatePensionCommand updatePrivatePensionCommand, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(updatePrivatePensionCommand);
    }

    [Route("UpdateModality")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdateModalityPrivatePensionCommand updateModalityPrivatePensionCommand, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(updateModalityPrivatePensionCommand);
    }


    [Route("Delete")]
    [HttpDelete]

    public async Task<ICommandResult> Delete([FromQuery] DeletePrivatePensionCommand deletePrivatePensionCommand, [FromServices] PrivatePensionCommandHandler handler)
    {
        return await handler.Handle(deletePrivatePensionCommand);
    }
}
