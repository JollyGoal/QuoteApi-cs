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

        // add a Quote from QuotePayload
        public async Task<List<Quote>> AddQuote(QuotePayload payload)
        {
            return await Task.Run(() =>
            {
                // get Id of latest Quote in _quotes
                long id = _quotes.Count > 0 ? _quotes[_quotes.Count - 1].Id + 1 : 1;

                // create new Quote
                Quote quote = new Quote() { Id = id, Text = payload.Text, Author = payload.Author, Category = payload.Category };
                // add to _quotes
                _quotes.Add(quote);
                return _quotes;
            });
        }

        // update a quote by id
        public async Task<Quote> UpdateQuote(long id, QuotePayload quote)
        {
            return await Task.Run(() =>
            {
                var match = _quotes.Find(q => q.Id == id);
                // change Author, Text and Category of mathc object
                match.Author = quote.Author;
                match.Text = quote.Text;
                match.Category = quote.Category;
                return match;
            });
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