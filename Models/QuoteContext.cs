using Microsoft.EntityFrameworkCore;

namespace QuoteApi_cs.Models
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Quote> Quote { get; set; }
    }
}