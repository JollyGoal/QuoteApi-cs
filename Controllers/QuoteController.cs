using Microsoft.AspNetCore.Mvc;
using QuoteApi_cs.Models;
using QuoteApi_cs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<Quote>> Get()
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
        public async Task<ActionResult<List<Quote>>> Post([FromBody] QuotePayload quote)
        {
            return await _quoteRepository.AddQuote(quote);
        }

        // PUT api/quote/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Quote>> Put(long id, [FromBody] QuotePayload quote)
        {
            return await _quoteRepository.UpdateQuote(id, quote);
        }

        // private readonly ITodoItemRepository _todoItemsRepository;
        // public TodoItemsController(ITodoItemRepository todoItemsRepository)
        // {
        //     _todoItemsRepository = todoItemsRepository;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<TodoItem>> GetTodoItems()
        // {
        //     return await _todoItemsRepository.Get();
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<TodoItem>> GetTodoItems(long id)
        // {
        //     return await _todoItemsRepository.Get(id);
        // }

        // [HttpPost]
        // public async Task<ActionResult<TodoItem>> PostTodoItems([FromBody] TodoItem todoItem)
        // {
        //     var newTodoItem = await _todoItemsRepository.Create(todoItem);
        //     return CreatedAtAction(nameof(GetTodoItems), new { id = todoItem.Id }, newTodoItem);
        // }

        // [HttpPut]
        // public async Task<ActionResult> PutTodoItems(long id, [FromBody] TodoItem todoItem)
        // {
        //     if (todoItem.Id != id)
        //     {
        //         return BadRequest();
        //     }
        //     await _todoItemsRepository.Update(todoItem);
        //     return NoContent();
        // }

        // // DELETE api/TodoItems/{id}
        // [HttpDelete("{id}")]
        // public async Task<ActionResult> DeleteTodoItems(long id)
        // {
        //     // check if the todo item exists
        //     var todoItem = await _todoItemsRepository.Get(id);
        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     await _todoItemsRepository.Delete(id);
        //     return NoContent();
        // }
    }
}