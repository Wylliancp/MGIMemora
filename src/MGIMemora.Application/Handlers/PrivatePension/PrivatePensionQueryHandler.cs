using MGIMemora.Application.Commands;
using MGIMemora.Application.Queries;
using MGIMemora.Application.Queries.PrivatePension;
using MGIMemora.Domain.Handlers;
using MGIMemora.Domain.Queries;
using MGIMemora.Domain.Repositories;

namespace MGIMemora.Application.Handlers.PrivatePension;

public class PrivatePensionQueryHandler(IPrivatePensionRepository privatePensionRepository)
    : IQueryHandler<GetByIdPrivatePensionQuery>, IQueryHandler<GetAllPrivatePensionQuery>
{
    public async Task<IQueryResult> Handle(GetByIdPrivatePensionQuery query)
    {
        var privatePension = await privatePensionRepository.GetByIdAsync(query.Id);
        return new GenericResultQuery(true, privatePension);
    }

    public async Task<IQueryResult> Handle(GetAllPrivatePensionQuery query)
    {
        var result = await privatePensionRepository.GetAllAsync();
        return new GenericResultQuery(true, result);
    }
}
