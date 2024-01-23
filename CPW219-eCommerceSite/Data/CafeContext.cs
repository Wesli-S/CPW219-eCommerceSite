using CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Data
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext>options) : base(options) 
        { 
        
        }

        public DbSet<MenuItem> menuItems { get; set; }
    }
}
