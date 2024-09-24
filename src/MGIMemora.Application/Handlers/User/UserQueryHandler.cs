using MGIMemora.Application.Commands;
using MGIMemora.Application.Queries.User;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Queries;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.User;

public class UserQueryHandler : IQueryHandler<GetByIdUserQuery>, IQueryHandler<GetAllUserQuery>
{
    private readonly IUserRepository _userRepository;

    public UserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IQueryResult> Handle(GetByIdUserQuery query)
    {
        var result = await _userRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, result);
    }

    public async Task<IQueryResult> Handle(GetAllUserQuery query)
    {
        var result = await _userRepository.GetAllAsync();
        return new GenericResultQuery(true, result);
    }
}
