using Microsoft.EntityFrameworkCore;
using NetMvc.Models.Db;

namespace NetMvc.Data
{
    public class StoreDbContext: DbContext
    {
        public DbSet<Merchant> Merchants { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Countrie> Countries { get; set; }

        public DbSet<Gender> Genders { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }
    }
}
