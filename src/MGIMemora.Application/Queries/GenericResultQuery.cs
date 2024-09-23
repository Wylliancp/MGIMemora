using MGIMemora.Domain.Queries;

namespace MGIMemora.Application.Commands
{
    public class GenericResultQuery : IQueryResult

    {
        public GenericResultQuery(bool success, object data)
        {
            Success = success;
            Data = data;
        }

       public bool Success { get; private set; }
       public object Data { get; private set; }
    }
}