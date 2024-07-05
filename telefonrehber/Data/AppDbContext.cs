using Microsoft.EntityFrameworkCore;
using telefonrehber.Models;

namespace telefonrehber.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<kisi> kisiler { get; set; }


    }
}
