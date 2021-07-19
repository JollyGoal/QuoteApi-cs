using Microsoft.AspNetCore.Mvc;
using QuoteApi_cs.Models;
using QuoteApi_cs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoriesRepository;
        public CategoryController(ICategoryRepository CategoriesRepository)
        {
            _CategoriesRepository = CategoriesRepository;
        }

        // GET api/Category
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _CategoriesRepository.GetCategories();
        }

        // GET api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(long id)
        {
            return await _CategoriesRepository.GetCategoryById(id);
        }

        // POST api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category Category)
        {
            Category newCategory = await _CategoriesRepository.AddCategory(Category);
            return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
        }

        // PUT api/Category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(long id, [FromBody] Category Category)
        {
            Category updatedCategory = await _CategoriesRepository.UpdateCategory(Category);
            return Ok(updatedCategory);
        }

        // DELETE api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(long id)
        {
            await _CategoriesRepository.DeleteCategoryById(id);
            return Ok();
        }
    }
}