using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QuoteApi_cs.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ApplicationContext _context;
        public SubscriberRepository(ApplicationContext context)
        {
            _context = context;
        }

        // add a subscriber to database
        public async Task Subscribe(Subscriber subscriber)
        {
            // handle validation methods from Subscriber class
            if (subscriber.IsValid())
            {
                // handle subscriber already exists
                var existingSubscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Contact == subscriber.Contact);
                if (existingSubscriber != null)
                {
                    throw new ArgumentException($"Subscriber with contact {subscriber.Contact} already exists.");
                }
                // add subscriber to database
                _context.Subscribers.Add(subscriber);
                await _context.SaveChangesAsync();
            }
            // if subscriber is invalid, throw an exception
            else
            {
                throw new ArgumentException(subscriber.GetErrors());
            }
        }

        // remove a subscriber from database by id
        public async Task Unsubscribe(long id)
        {
            var subscriber = _context.Subscribers.FirstOrDefault(s => s.Id == id);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Subscriber with id {id} does not exist.");
            }
        }

        // get all subscribers from database
        public async Task<IEnumerable<Subscriber>> GetAllSubscribers()
        {
            return await _context.Subscribers.ToListAsync();
        }

        // send a message to a subscriber
        public async Task SendMessage(Subscriber subscriber, string message)
        {
            // check if subscriber exists
            var existingSubscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Contact == subscriber.Contact);
            if (existingSubscriber == null)
            {
                throw new ArgumentException($"Subscriber with contact {subscriber.Contact} does not exist.");
            }
            // check subscriber's contact preferences
            if (subscriber.IsValidPhone())
            {
                // TODO send message to subscriber's phone number vie API call
            }
            else
            {
                // TODO send message to subscriber's email address via SMTP
            }
        }

    }
}