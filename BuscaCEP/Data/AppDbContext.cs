using BuscaCEP.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaCEP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<imagem> imagems { get; set; }
    }
}
