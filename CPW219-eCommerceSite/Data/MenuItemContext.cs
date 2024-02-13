using CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Data
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(DbContextOptions<MenuItemContext> options) 
            : base(options)
        { 
        
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<CPW219_eCommerceSite.Models.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    }
}
