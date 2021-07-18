using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Repositories
{
    // Interface for the Quote Repository
    public interface IQuoteRepository
    {
        // get all quotes
        Task<List<Quote>> GetQuotes();
        // get a quote by Id
        Task<Quote> GetQuoteById(long id);
        // add a quote
        Task<Quote> AddQuote(Quote quote);
        // update a quote
        Task<Quote> UpdateQuote(Quote quote);
        // delete a quote by Id
        Task<bool> DeleteQuoteById(long id);
        // get all quotes by Category
        Task<List<Quote>> GetQuotesByCategory(Category category);
        // get random quote
        Task<Quote> GetRandomQuote();
    }
}