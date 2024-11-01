using MGIMemora.Application.Commands.User;
using MGIMemora.Application.Handlers.User;
using MGIMemora.Application.Queries.User;
using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MGIMemora.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger) : ControllerBase
{

    private readonly ILogger<UserController> _logger = logger;

    [Route("GetTById")]
    [HttpGet]

    public async Task<IQueryResult> GetById([FromQuery] GetByIdUserQuery query, [FromServices] UserQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IQueryResult> GetAll([FromQuery] GetAllUserQuery query, [FromServices] UserQueryHandler handler)
    {
        return await handler.Handle(query);
    }

    [Route("Create")]
    [HttpPost]

    public async Task<ICommandResult> Create([FromBody] CreateUserCommand command, [FromServices] UserCommandHandler handler)
    {
        return await handler.Handle(command);
    }

    [Route("UpdateEmail")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdateEmailUserCommand command, [FromServices] UserCommandHandler handler)
    {
        return await handler.Handle(command);
    }

    [Route("UpdateRoles")]
    [HttpPut]

    public async Task<ICommandResult> Update([FromBody] UpdateRolesUserCommand command, [FromServices] UserCommandHandler handler)
    {
        return await handler.Handle(command);
    }


    [Route("Delete")]
    [HttpDelete]

    public async Task<ICommandResult> Delete([FromQuery] DeleteUserCommand command, [FromServices] UserCommandHandler handler)
    {
        return await handler.Handle(command);
    }

    [Route("Login")]
    [HttpPost]

    public async Task<ICommandResult> Authentication([FromQuery] LoginUserCommand command, [FromServices] UserCommandHandler handler)
    {
        return await handler.Handle(command);
    }
}
