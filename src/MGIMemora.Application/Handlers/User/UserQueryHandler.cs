using MGIMemora.Application.Commands;
using MGIMemora.Application.Queries;
using MGIMemora.Application.Queries.User;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Queries;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.User;

public class UserQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetByIdUserQuery>, IQueryHandler<GetAllUserQuery>
{
    public async Task<IQueryResult> Handle(GetByIdUserQuery query)
    {
        var result = await userRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, result);
    }

    public async Task<IQueryResult> Handle(GetAllUserQuery query)
    {
        var result = await userRepository.GetAllAsync();
        return new GenericResultQuery(true, result);
    }
}
