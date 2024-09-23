using MGIMemora.Domain.Commands;
using MGIMemora.Domain.Queries;

namespace MGIMemora.Domain.Handlers
{
    public interface IQueryHandler<T> where T : IQuery
    {
        Task<IQueryResult> Handle(T query);
    }
}
