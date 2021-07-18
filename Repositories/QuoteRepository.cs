using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuoteApi_cs.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        // Add your QuoteApi_cs.Models.Quote objects here
        private List<Quote> _quotes;
        public QuoteRepository()
        {
            _quotes = new List<Quote>();
        }
        // implement interface methods

        // get all quotes
        public async Task<List<Quote>> GetQuotes()
        {
            return await Task.Run(() => { return _quotes; });
        }

        // get a quote by id
        public async Task<Quote> GetQuoteById(long id)
        {
            return await Task.Run(() => { return _quotes.Find(q => q.Id == id); });
        }

        // add a quote
        public async Task<Quote> AddQuote(Quote quote)
        {
            return await Task.Run(() => { _quotes.Add(quote); return quote; });
        }

        // update a quote
        public async Task<Quote> UpdateQuote(Quote quote)
        {
            return await Task.Run(() => { _quotes.Remove(quote); _quotes.Add(quote); return quote; });
        }

        // delete a quote by Id
        public async Task<Boolean> DeleteQuoteById(long id)
        {
            return await Task.Run(() => { _quotes.Remove(_quotes.Find(q => q.Id == id)); return true; });
        }

        // get all quotes by category
        public async Task<List<Quote>> GetQuotesByCategory(Category category)
        {
            return await Task.Run(() => { return _quotes.FindAll(q => q.Category == category); });
        }

        // get a random quote
        public async Task<Quote> GetRandomQuote()
        {
            return await Task.Run(() => { return _quotes[new Random().Next(0, _quotes.Count)]; });
        }
    }
}