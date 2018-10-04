using Microsoft.EntityFrameworkCore;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Broker> Brokers { get; set; }
        public DbSet<App> Apps { get; set; }
      
    }
}