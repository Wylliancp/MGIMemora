using MGIMemora.Domain.Entities;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{   
    private readonly MGIContext _context;

    public UserRepository(MGIContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.Where(x => x.Id == id)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

        if(user == default) return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync() ?? default!;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<User> LoginAsync(string Email, string Password)
    {
        return await _context.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefaultAsync() ?? default!;
    }
}
