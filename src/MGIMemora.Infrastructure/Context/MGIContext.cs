using MGIMemora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MGIMemora.Infrastructure.Context
{
    public class MGIContext : DbContext
    {
        public MGIContext(DbContextOptions<MGIContext> contextOptions) : base(contextOptions)
        {
            
        }
        public DbSet<PrivatePension> PrivatePensions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}