using MGIMemora.Domain.Entities;

namespace MGIMemora.Domain.Repositories
{
    public interface IPrivatePensionRepository
    {
        Task<PrivatePension> GetByIdAsync(int id);
        Task<IEnumerable<PrivatePension>> GetAllAsync();
        Task CreateAsync(PrivatePension privatePension);
        Task UpdateAsync(PrivatePension privatePension);
        Task DeleteAsync(int id);
    }
}