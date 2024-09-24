
using MGIMemora.Domain.Queries;

namespace MGIMemora.Application.Queries.User;

public class GetByIdUserQuery : IQuery
{
    public int Id { get; set; }
}

