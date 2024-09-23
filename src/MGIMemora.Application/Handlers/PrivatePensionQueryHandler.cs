using MGIMemora.Application.Commands;
using MGIMemora.Application.Queries.PrivatePension;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Queries;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers;

public class PrivatePensionQueryHandler : IQueryHandler<GetByIdQuery>, IQueryHandler<GetAllQuery>
{
    private readonly IPrivatePensionRepository _privatePensionRepository;

    public PrivatePensionQueryHandler(IPrivatePensionRepository privatePensionRepository)
    {
        _privatePensionRepository = privatePensionRepository;
    }
    public async Task<IQueryResult> Handle(GetByIdQuery query)
    {
        var result = await _privatePensionRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, result);
    }

    public async Task<IQueryResult> Handle(GetAllQuery query)
    {
        var result = await _privatePensionRepository.GetAllAsync();
        return new GenericResultQuery(true, result);
    }
}
