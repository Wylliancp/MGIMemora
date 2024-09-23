
using MGIMemora.Domain.Queries;

namespace MGIMemora.Application.Queries.PrivatePension;

public class GetByIdQuery : IQuery
{
    public int Id { get; set; }
}

