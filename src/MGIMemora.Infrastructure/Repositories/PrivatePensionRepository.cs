using MGIMemora.Domain.Entities;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Repositories;

public class PrivatePensionRepository : IPrivatePensionRepository
{   
    private readonly MGIContext _context;

    public PrivatePensionRepository(MGIContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(PrivatePension privatePension)
    {
        await _context.PrivatePensions.AddAsync(privatePension);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var privatePension = await _context.PrivatePensions.Where(x => x.Id == id)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

        if(privatePension == default) return;

        _context.PrivatePensions.Remove(privatePension);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PrivatePension>> GetAllAsync()
    {
        return await _context.PrivatePensions.ToListAsync();
    }

    public async Task<PrivatePension> GetByIdAsync(int id)
    {
        return await _context.PrivatePensions.Where(x => x.Id == id).FirstOrDefaultAsync() ?? default!;
    }

    public async Task UpdateAsync(PrivatePension privatePension)
    {
        _context.Entry(privatePension).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
