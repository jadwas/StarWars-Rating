using Microsoft.EntityFrameworkCore;

namespace StarWars_Rating.DataAccess.Models
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options) : base(options)
        {

        }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>().ToTable("Rate");
        }
    }
}
