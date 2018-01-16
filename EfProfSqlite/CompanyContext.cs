using Microsoft.EntityFrameworkCore;

namespace EfProfSqlite
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Company> Company => Set<Company>();
    }
}