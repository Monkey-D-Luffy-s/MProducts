using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.Data
{
    public class ProductDbConntext : DbContext
    {
        public ProductDbConntext(DbContextOptions<ProductDbConntext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
