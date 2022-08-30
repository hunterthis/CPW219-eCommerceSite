
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Data
{
    public class Registration :DbContext
    {
        public Registration(DbContextOptions<Registration> options) : base(options) 
        {
        
        }
        public DbSet<Shopper> Shoppers { get; set; }
        
    }
}
