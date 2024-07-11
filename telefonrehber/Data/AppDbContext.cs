using Microsoft.EntityFrameworkCore;
using telefonrehber.Models;

namespace telefonrehber.Data
{
<<<<<<< HEAD
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<kisi> kisiler { get; set; }

        public DbSet<SearchHistory> SearchHistories { get; set; }

=======
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<kisi> kisiler { get; set; }

>>>>>>> 961afc2caab843f24c758815fd033a436f69f418

    }
}
