using Microsoft.EntityFrameworkCore;

namespace QuoteApi_cs.Models
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<QuoteContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Quote> Authors { get; set; }
    }
}