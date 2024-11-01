using MGIMemora.Domain.Entities;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Repositories;

public class PrivatePensionRepository(MGIContext context) : IPrivatePensionRepository
{
    public async Task CreateAsync(PrivatePension privatePension)
    {
        await context.PrivatePensions.AddAsync(privatePension);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var privatePension = await context.PrivatePensions.Where(x => x.Id == id)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

        if(privatePension == default) return;

        context.PrivatePensions.Remove(privatePension);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PrivatePension>> GetAllAsync()
    {
        return await context.PrivatePensions.ToListAsync();
    }

    public async Task<PrivatePension> GetByIdAsync(int id)
    {
        return await context.PrivatePensions.Where(x => x.Id == id).FirstOrDefaultAsync() ?? default!;
    }

    public async Task UpdateAsync(PrivatePension privatePension)
    {
        context.Entry(privatePension).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
