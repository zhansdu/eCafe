using Microsoft.EntityFrameworkCore;
using newProjectJs.Models;

namespace newProjectJs.Data
{
    public class CafeContext : DbContext
    {
        public CafeContext (DbContextOptions<CafeContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Food  {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Role> Roles {get;set;}
    }
}