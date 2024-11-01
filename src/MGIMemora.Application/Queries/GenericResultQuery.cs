using MGIMemora.Domain.Queries;

namespace MGIMemora.Application.Queries
{
    public class GenericResultQuery(bool success, object data) : IQueryResult

    {
        public bool Success { get; private set; } = success;
       public object Data { get; private set; } = data;
    }
}