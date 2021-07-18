using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QuoteApi_cs.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        // Add your QuoteApi_cs.Models.Quote objects here
        private readonly ApplicationContext _context;
        public QuoteRepository(ApplicationContext context)
        {
            _context = context;
        }
        // implement interface methods

        // get all quotes
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            return await _context.Quotes.Include("Author").Include("Category").ToListAsync();
        }

        // get a quote by id
        public async Task<Quote> GetQuoteById(long id)
        {
            return await _context.Quotes.Include("Author").Include("Category").FirstOrDefaultAsync(e => e.Id == id);
        }

        // add a Quote from QuotePayload
        public async Task<Quote> AddQuote(QuotePayload payload)
        {
            // get id of last inserted quote
            Quote lastQuote = await _context.Quotes.OrderByDescending(q => q.Id).FirstOrDefaultAsync();
            long newId = lastQuote == null ? 0 : lastQuote.Id + 1;

            // handle foreign key constraints for author and category
            Author author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == payload.AuthorId);
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == payload.CategoryId);
            if (author == null)
            {
                throw new ArgumentException($"Author with id {payload.AuthorId} does not exist");
            }
            if (category == null)
            {
                throw new ArgumentException($"Category with id {payload.CategoryId} does not exist");
            }

            Quote quote = new Quote()
            {
                Id = newId,
                Author = payload.Author,
                Text = payload.Text,
                Category = payload.Category,
            };

            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return quote;
        }

        // update a quote by id
        public async Task<Quote> UpdateQuote(long id, QuotePayload quote)
        {
            Quote quoteToUpdate = await _context.Quotes.FindAsync(id);
            quoteToUpdate.Author = quote.Author;
            quoteToUpdate.Text = quote.Text;
            quoteToUpdate.Category = quote.Category;

            // alternative way to update
            // _context.Entry(quoteToUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return quoteToUpdate;
        }

        // delete a quote by Id
        public async Task<Boolean> DeleteQuoteById(long id)
        {
            Quote quoteToDelete = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quoteToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        // get all quotes by category
        public async Task<List<Quote>> GetQuotesByCategory(Category category)
        {
            return await _context.Quotes.Where(q => q.Category == category).ToListAsync();
        }

        // get a random quote
        public async Task<Quote> GetRandomQuote()
        {
            return await _context.Quotes.OrderBy(q => Guid.NewGuid()).FirstOrDefaultAsync();
        }
    }
}