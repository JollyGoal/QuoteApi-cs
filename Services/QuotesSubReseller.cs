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
    public class QuotesSubReseller : BackgroundService
    {
        private readonly ILogger<QuoteCollector> _logger;
        private readonly IQuoteRepository _quoteRepository;
        private readonly ISubscriberRepository _subscriberRepository;

        public QuotesSubReseller(IServiceProvider serviceProvider, ILogger<QuoteCollector> logger)
        {
            _logger = logger;
            // _quoteRepository = quoteRepository;
            _quoteRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IQuoteRepository>();
            _subscriberRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ISubscriberRepository>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Quotes reseller worker started.");

                // get all quotes
                IEnumerable<Quote> quotes = await _quoteRepository.GetQuotes();

                // get all subscribers
                IEnumerable<Subscriber> subscribers = await _subscriberRepository.GetAllSubscribers();

                // prepare message for subscribers
                string message = string.Empty;
                foreach (Quote quote in quotes)
                {
                    message += quote.Author.Name + " - " + quote.Category.Name + ": " + quote.Text + "\n";
                }

                // run the task each 24 hours
                // await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}