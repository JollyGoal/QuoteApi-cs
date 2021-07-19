using Microsoft.AspNetCore.Mvc;
using QuoteApi_cs.Models;
using QuoteApi_cs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorsRepository;
        public AuthorController(IAuthorRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        // GET api/author
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _authorsRepository.GetAuthors();
        }

        // GET api/author/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(long id)
        {
            return await _authorsRepository.GetAuthorById(id);
        }

        // POST api/author
        [HttpPost]
        public async Task<ActionResult<Author>> Post([FromBody] Author author)
        {
            Author newAuthor = await _authorsRepository.AddAuthor(author);
            return CreatedAtAction(nameof(Get), new { id = newAuthor.Id }, newAuthor);
        }

        // PUT api/author/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Put(long id, [FromBody] Author author)
        {
            Author updatedAuthor = await _authorsRepository.UpdateAuthor(author);
            return Ok(updatedAuthor);
        }
    }
}