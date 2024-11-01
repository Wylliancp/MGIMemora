using MGIMemora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Context
{
    public class MGIContext(DbContextOptions<MGIContext> contextOptions) : DbContext(contextOptions)
    {
        public DbSet<PrivatePension> PrivatePensions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}