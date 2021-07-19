using Microsoft.AspNetCore.Mvc;
using QuoteApi_cs.Models;
using QuoteApi_cs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscriberRepository _subscribersRepository;
        public SubscribeController(ISubscriberRepository subscribersRepository)
        {
            _subscribersRepository = subscribersRepository;
        }

        // GET api/subscribe
        [HttpGet]
        public async Task<IEnumerable<Subscriber>> Get()
        {
            return await _subscribersRepository.GetAllSubscribers();
        }

        // POST api/subscribe
        [HttpPost]
        public async Task Post([FromBody] Subscriber subscriber)
        {
            await _subscribersRepository.Subscribe(subscriber);
        }

        // DELETE api/subscribe/{id}
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _subscribersRepository.Unsubscribe(id);
        }

    }
}