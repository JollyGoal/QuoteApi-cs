using Microsoft.AspNetCore.Mvc;
using QuoteApi_cs.Models;
using QuoteApi_cs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace QuoteApi_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        // GET api/quote
        [HttpGet]
        public async Task<IEnumerable<Quote>> Get()
        {
            return await _quoteRepository.GetQuotes();
        }

        // GET api/quote/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> Get(long id)
        {
            return await _quoteRepository.GetQuoteById(id);
        }

        // POST api/quote
        [HttpPost]
        public async Task<ActionResult<Quote>> Post([FromBody] QuotePayload quote)
        {
            Quote newQuote = await _quoteRepository.AddQuote(quote);
            return CreatedAtAction(nameof(Get), new { id = newQuote.Id }, newQuote);
        }

        // PUT api/quote/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Quote>> Put(long id, [FromBody] QuotePayload quote)
        {
            Quote updatedQuote = await _quoteRepository.UpdateQuote(id, quote);
            return Ok(updatedQuote);
        }
    }
}