using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPIdemo.Model;

namespace WebAPIdemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Shirt> Shirts { get; set; }
    }
}
