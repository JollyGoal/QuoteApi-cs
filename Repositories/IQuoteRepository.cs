using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuoteApi_cs.Repositories
{
    // Interface for the Quote Repository
    public interface IQuoteRepository
    {
        // get all quotes
        Task<IEnumerable<Quote>> GetQuotes();
        // get a quote by Id
        Task<Quote> GetQuoteById(long id);
        // add a quote
        Task<Quote> AddQuote(QuotePayload quotePayload);
        // update a quote
        Task<Quote> UpdateQuote(long id, QuotePayload quotePayload);
        // delete a quote by Id
        Task<bool> DeleteQuoteById(long id);
        // get all quotes by Category
        Task<IEnumerable<Quote>> GetQuotesByCategory(Category category);
        // get random quote
        Task<Quote> GetRandomQuote();
        // drop quotes that are older than a parameter DateTime field and returns deleted Quotes if any
        Task<IEnumerable<Quote>> DropQuotesOlderThan(DateTime olderThan);
    }
}