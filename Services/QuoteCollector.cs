using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuoteApi_cs.Repositories;
using QuoteApi_cs.Models;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace QuoteApi_cs.Services
{
    public class QuoteCollector : BackgroundService
    {
        private readonly ILogger<QuoteCollector> _logger;
        private readonly IQuoteRepository _quoteRepository;

        public QuoteCollector(IServiceProvider serviceProvider, ILogger<QuoteCollector> logger)
        {
            _logger = logger;
            // _quoteRepository = quoteRepository;
            _quoteRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IQuoteRepository>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                bool DEBUG = true;  // change to false for production
                if (DEBUG)
                {
                    _logger.LogInformation("Collecting Quote");

                    // get all quotes for debug purposes
                    IEnumerable<Quote> quotes = await _quoteRepository.GetQuotes();
                    // log all elements of the enumerable
                    foreach (Quote quote in quotes)
                    {
                        _logger.LogInformation($"Quote: {quote.Id} - {quote.Text}");
                    }
                }

                // get 24 hours before now
                DateTime olderThan = DateTime.Now;
                olderThan = olderThan.AddDays(-1);

                //delete all quotes older than 24 hours
                await _quoteRepository.DropQuotesOlderThan(olderThan);

                // run the task each 5 minutes
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

    }
}