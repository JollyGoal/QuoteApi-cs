using System.Threading.Tasks;
using QuoteApi_cs.Models;
using System.Collections.Generic;

namespace QuoteApi_cs.Repositories
{
    public interface ISubscriberRepository
    {
        // subscribe to daily quotes
        Task Subscribe(Subscriber subscriber);
        // unsubscribe from daily quotes
        Task Unsubscribe(long id);
        // get all subscribers
        Task<IEnumerable<Subscriber>> GetAllSubscribers();
    }
}