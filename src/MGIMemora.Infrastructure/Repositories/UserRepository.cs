using MGIMemora.Domain.Entities;
using MGIMemora.Domain.Repositories;
using MGIMemora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Repositories;

public class UserRepository(MGIContext context) : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await context.Users.Where(x => x.Id == id)
                                                           .AsNoTracking()
                                                           .FirstOrDefaultAsync();

        if(user == default) return;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync() ?? default!;
    }

    public async Task UpdateAsync(User user)
    {
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        return await context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync() ?? default!;
    }
}
