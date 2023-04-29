

global using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting.Server;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
                                            
            optionsBuilder.UseSqlServer("server=.;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
