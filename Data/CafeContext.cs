using Microsoft.EntityFrameworkCore;
using newProjectJs.Models;

namespace newProjectJs.Data
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Food { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<OrderFood> OrderFood { get; set; }
    }
}